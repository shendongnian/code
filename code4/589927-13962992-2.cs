    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2Helpers
    {
        public static class My35Extensions
        {   
            public static  IEnumerable<IEnumerable<T>> ToIEnumerableOfIEnumerable<T>(this List<List<T>> value)
            {
                foreach (var v1 in value)
                {
                    yield return v1;
                }
            }
        }
    }
