    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        internal enum sampleEnum
        {
            a,
            b,
            c,
            d
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var a = new Dictionary<sampleEnum, sampleValue>();
                var b = new Dictionary<sampleEnum, sampleValue>();
    
                a.Add(sampleEnum.a, new sampleValue());
                a.Add(sampleEnum.b, new sampleValue());
    
                b.Add(sampleEnum.a, new sampleValue());
                b.Add(sampleEnum.b, new sampleValue());
                b.Add(sampleEnum.c, new sampleValue());
                b.Add(sampleEnum.d, new sampleValue());
    
                // Add missing b values into a
                foreach (var objItem in from l2 in b where !a.ContainsKey(l2.Key) select l2)
                {
                    a.Add(objItem.Key, objItem.Value);
                }
    
                // Merge b's values into a
                foreach (var objItem in from l2 in b where a.ContainsKey(l2.Key) select l2)
                {
                    a[objItem.Key] = objItem.Value;
                }
    
                System.Diagnostics.Debug.Assert(true);
            }
        }
    
        internal class sampleValue
        {
        }
    }
