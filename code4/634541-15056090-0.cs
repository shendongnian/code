    var sortedScoreLines = GetLines("inputFilePath")
            .Select(p => new { num = int.Parse(p.Split(':')[0]), name = p.Split(':')[1] })
            .OrderBy(p => p.num)
            .ThenBy(p => p.name)
            .Select(p => string.Format("{0}:{1}", p.num, p.name))
            .ToList();
        private static List<string> GetLines(string inputFile)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), inputFile);
            return File.ReadLines(filePath).ToList();
        }
