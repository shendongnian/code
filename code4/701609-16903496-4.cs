        private static void Main(string[] args)
        {
            FileStream stream = File.OpenRead(@"C:\in.txt");
            Encoding encoding = Encoding.GetEncoding(1252);
            Task<string> result = stream.ReadLineAsync(encoding);
            result.ContinueWith(o =>
                {
                    Console.Write(o.Result);
                    stream.Dispose();
                });
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
