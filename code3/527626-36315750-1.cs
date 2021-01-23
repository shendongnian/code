        static void Main(string[] args)
        {
            List<string> patterns = new List<string>
            {
                "class",
                "foreach",
                "main",
            };
            string searchPattern = "*.cs";
            string directory = "C:\\SearchDirectory";
            DateTime start = DateTime.UtcNow;
            FindInDirectory.Search(directory, searchPattern, patterns);
            Console.WriteLine((DateTime.UtcNow - start).TotalMilliseconds);
            Console.ReadLine();
        }
