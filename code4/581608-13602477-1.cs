    using System;
    using System.Collections.Specialized;
    namespace ConsoleApplication1
    {
        class ListDegree:OrderedDictionary
        {
        }
        class Program
        {
            public static void Main()
            {
                var _listDegree = new ListDegree();
                _listDegree.Add("ali", 324);
                _listDegree.Add("veli", 553);
                int i = -1;
                foreach (var item in _listDegree)
                {
                    i++;
                }
                if (i == -1)
                    Console.WriteLine("Error: \"Code = 1\"");
                else
                    Console.WriteLine("Error: \"" + _listDegree[i] + "\"");
            }
        }
    }
