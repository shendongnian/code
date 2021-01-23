    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    namespace TestCrash
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Parallel.ForEach(Enumerable.Range(1, 1000).ToList(), i =>
                    {
                        Console.WriteLine(i);
                        using (var c = new HttpClient { Timeout = TimeSpan.FromMilliseconds(1) })
                        {
                            var t = c.GetAsync("http://microsoft.com");
                            t.RunSynchronously(); //<--comment this line and it crashes
                            Console.WriteLine(t.Result);
                        }
                    });
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
                Console.ReadKey();
            }
        }
    }
