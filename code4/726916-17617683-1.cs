    using System;
    using System.Runtime.CompilerServices;
    namespace DataCellExtender
    {
        #region sample 3rd party class
        public class DataCell
        {
            public int Field1;
            public int Field2;
        }
        #endregion
        public static class DataCellExtension
        {
            //ConditionalWeakTable is available in .NET 4.0+
            //if you use an older .NET, you have to create your own CWT implementation (good luck with that!)
            static readonly ConditionalWeakTable<DataCell, IntObject> Flags = new ConditionalWeakTable<DataCell, IntObject>();
            public static int GetFlags(this DataCell dataCell) { return Flags.GetOrCreateValue(dataCell).Value; }
            public static void SetFlags(this DataCell dataCell, int newFlags) { Flags.GetOrCreateValue(dataCell).Value = newFlags; }
            class IntObject
            {
                public int Value;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var dc = new DataCell();
                dc.SetFlags(42);
                var flags = dc.GetFlags();
                Console.WriteLine(flags);
            }
        }
    }
