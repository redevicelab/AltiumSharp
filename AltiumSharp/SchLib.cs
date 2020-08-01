﻿using System.Collections;
using System.Collections.Generic;
using AltiumSharp.Records;

namespace AltiumSharp
{
    public class SchLib : SchData<SchLibHeader, SchComponent>, IEnumerable<SchComponent>
    {
        public override SchLibHeader Header { get; }

        public SchLib() : base()
        {
            Header = new SchLibHeader(Items);
        }

        public void Add(SchComponent component)
        {
            if (string.IsNullOrEmpty(component.LibReference))
            {
                component.LibReference = $"Component_{Items.Count+1}";
            }

            Items.Add(component);
        }

        IEnumerator<SchComponent> IEnumerable<SchComponent>.GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}
