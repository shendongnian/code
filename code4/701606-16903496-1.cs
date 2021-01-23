        private static void Main(string[] args)
        {
            FileStream stream = File.OpenRead(@"C:\in.txt");
            Task<string> result = stream.ReadLineAsync(Encoding.ASCII);
            result.ContinueWith(o =>
                {
                    Console.Write(o.Result);
                    stream.Dispose();
                });
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
