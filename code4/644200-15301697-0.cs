    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string a = "disfuncshunal";
                string b = "dysfunctional";
    
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        sb.Append("[");
                        sb.Append(a[i]);
                        sb.Append("]");
    
                        continue;
                    }
    
                    sb.Append(a[i]);
                }
    
                var str = sb.ToString();
                var startIndex = str.IndexOf("[");
                var endIndex = str.LastIndexOf("]");
    
                var start = str.Substring(0, startIndex + 1);
                var mid = str.Substring(startIndex + 1, endIndex - 1);
                var end = str.Substring(endIndex);
    
                Console.WriteLine(start + mid.Replace("[", "").Replace("]", "") + end);
            }
        }
    }
