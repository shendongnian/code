    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace _16853758
    {
        class Program
        {
            static void Main(string[] args)
            {
                ArrayList arrayList = new ArrayList();
    
                var a = CountOccurences<String>(arrayList.Cast<String>().ToArray());
                var v = CountOccurences<String>(arrayList.OfType<String>().ToArray());
            }
    
            public static Dictionary<T, int> CountOccurences<T>(IEnumerable<T> items) { return new Dictionary<T, int>(); }
        }
    }
