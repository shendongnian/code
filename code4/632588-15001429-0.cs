    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ListsAndArrays
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int[]> propIDs = new List<int[]>();
                propIDs.Add(new[] { 1, 2 });
                propIDs.Add(new[] { 4, 5 });
                propIDs.Add(new[] { 1, 5 });
                propIDs.Add(new[] { 1, 2 });
                propIDs.Add(new[] { 1, 5 });
    
                var distinct = propIDs.Distinct(new DistinctIntegerArrayComparer());
    
                foreach (var item in distinct)
                {
                    Console.WriteLine("{0}|{1}", item[0], item[1]);
                }
    
                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }
            }
    
            private class DistinctIntegerArrayComparer : IEqualityComparer<int[]>
            {
                public bool Equals(int[] x, int[] y)
                {
                    if (x.Length != y.Length) { return false; }
                    else if (x.Length != 2 || y.Length != 2) { return false; }
    
                    return x[0] == y[0] && x[1] == y[1];
                }
    
                public int GetHashCode(int[] obj)
                {
                    return -1;
                }
            }
    
        }
    }
