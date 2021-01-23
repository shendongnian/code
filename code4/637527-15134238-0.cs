        static void Main(string[] args)
        {
            // returns a list of file names, which have duplicate MD5 hashes
            var duplicates = CalcDuplicates(new[] {"Hello.txt", "World.txt"});
        }
        private static IEnumerable<string> CalcDuplicates(IEnumerable<string> fileNames)
        {
            return fileNames.GroupBy(CalcMd5OfFile)
                            .Where(g => g.Count() > 1)
                            // skip SelectMany() if you'd like the duplicates grouped by their hashes as group key
                            .SelectMany(g => g);
        }
        private static string CalcMd5OfFile(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }
