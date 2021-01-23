    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
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
                var r = new Dictionary<sampleEnum, sampleValue>();
    
                a.Add(sampleEnum.a, new sampleValue());
                a.Add(sampleEnum.b, new sampleValue());
    
                b.Add(sampleEnum.a, new sampleValue());
                b.Add(sampleEnum.b, new sampleValue());
                b.Add(sampleEnum.c, new sampleValue());
                b.Add(sampleEnum.d, new sampleValue());
    
                foreach (var objItem in from l2 in b where !a.ContainsKey(l2.Key) select l2)
                {
                    a.Add(objItem.Key, objItem.Value);
                }
     
            }
        }
    
        internal class sampleValue
        {
        }
    }
