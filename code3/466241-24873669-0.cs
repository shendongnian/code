        static void Main(string[] args)
        {
            StreamReader reader;
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/c echo hi";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            reader = p.StandardOutput;
            byte[] result = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            Console.WriteLine(result.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(result));
            Console.ReadLine();
        }
