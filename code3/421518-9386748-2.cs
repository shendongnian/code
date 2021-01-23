            var filePath = Directory.GetFiles(@"\\Pontos\completed\", "*_*.csv")
                .Select(p => new { Path = p, Date = File.GetLastWriteTime(p), CreatedDate = File.GetCreationTime(p) })
                .OrderByDescending(x => x.Date)
                .Where(x => x.Date >= DateTime.Now)
                .FirstOrDefault();
            Console.WriteLine(filePath.Date);
            Console.WriteLine(filePath.Path);
            Console.WriteLine(filePath.CreatedDate);
