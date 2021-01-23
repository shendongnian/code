        static void Main(string[] args)
        {
            string str = "123456#23876587234687237*723547623547523745273#";
            Console.WriteLine("Join+Where");
            Test(s => String.Join("",s.Where(char.IsDigit)), str);
            Console.WriteLine("ArrayOperation");
            Test(s => new string(Array.FindAll(s.ToCharArray(), char.IsDigit)), str);
            Console.WriteLine("Join+Select");
            Test(s => string.Join("", s.Select(r=> char.IsDigit(r) ? r.ToString():"")), str);
            Console.WriteLine("ReplaceReplace");
            Test(s => s.Replace("*", "").Replace("#", ""), str);
            Console.WriteLine("Regex");
            Test(s => Regex.Replace(s, "[#*]", ""), str);
            Console.WriteLine("Regex");
            Regex rx = new Regex("[#*]", RegexOptions.Compiled);
            rx.Match(""); // Precompile for better results
            Test(s => rx.Replace(s, ""), str);
            Console.WriteLine("StringBuilder");
            Test(s => new StringBuilder(s).Replace("*", "").Replace("#", "").ToString(), str);
            Console.ReadLine();
        }
        public static void Test(Func<string,string> proposedSolution, string input)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Thread.Sleep(5000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                string val = proposedSolution(input);
                Debug.Write(val);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
