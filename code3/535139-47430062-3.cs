       static void Main(string[] args)
        {
            var a = Enumerable.Range(0, 100000);
            var b = Enumerable.Range(10000000, 1000);
            var t = new Stopwatch();
            t.Start();
            Repeat(()=> { Contain(a, b); });
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);//490ms
            var a1 = Enumerable.Range(0, 100000).ToList();
            var a2 = b.ToList();
            t.Restart();
            Repeat(()=> { Contain(a1, a2); });
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);//203ms
            t.Restart();
            Repeat(()=>{ a.Intersect(b).Any(); });
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);//190ms
            t.Restart();
            Repeat(()=>{ b.Intersect(a).Any(); });
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);//497ms
            t.Restart();
            a.Any(b.Contains);
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);//600ms
        }
        private static void Repeat(Action a)
        {
            for (int i = 0; i < 100; i++)
            {
                a();
            }
        }
