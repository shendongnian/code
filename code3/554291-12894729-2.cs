    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<object[]>
                {
                    new object[] {"tamilnadu","capital",2000000},
                    new object[] {"other","capital",9490384},
                    new object[] {"tamilnadu","capital",2000000}
                };
    
                foreach (var item in list)
                {
                    Console.WriteLine(string.Format("{0} | {1} | {2}", item[0], item[1], item[2]));
                }
    
                Console.WriteLine();
                Console.WriteLine();
    
                var distinctList = list.Distinct(new MyArrayComparer());
    
                foreach (var item in distinctList)
                {
                    Console.WriteLine(string.Format("{0} | {1} | {2}", item[0], item[1], item[2]));
                }
            }
    
            class MyArrayComparer : EqualityComparer<object[]>
            {
                public override bool Equals(object[] x, object[] y)
                {
                    if (x.Length != y.Length) { return false; }
                    for (int i = 0; i < x.Length; i++)
                    {
                        if (!x[i].Equals(y[i]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
    
                public override int GetHashCode(object[] obj)
                {
                    return 0;
                }
            }
        }
    }
