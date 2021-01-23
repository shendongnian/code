    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace TestesConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] vers = new[]
                                  {
                                      "14.10",
                                      "14.9",
                                      "14.10.1",
                                  };
                var ordered = vers.OrderBy(x => x, new VersionComparer()).ToList();
            }
        }
        public class VersionComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                string[] xs = x.Split('.');
                string[] ys = y.Split('.');
                int maxLoop = Math.Min(xs.Length, ys.Length);
                for (int i = 0; i < maxLoop; i++)
                {
                    if(int.Parse(xs[i]) > int.Parse(ys[i]))
                    {
                        return 1;
                    }
                    else if(int.Parse(xs[i]) < int.Parse(ys[i]))
                    {
                        return -1;
                    }
                }
                if(xs.Length > ys.Length)
                {
                    return 1;
                }
                else if(xs.Length < ys.Length)
                {
                    return -1;
                }
                return 0;
            }
        }
    }
