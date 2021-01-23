    using (var reader = new StreamReader(@"C:\file-here.txt")) {
        bool chevyFound = false;
        while (!reader.EndOfStream) {
            var line = reader.ReadLine().Trim();
            if (chevyFound && line.EndsWith("Ford")) {
                var fordDate = DateTime.Parse(line.Substring(0, 19));
                Console.WriteLine("Ford Date: {0}", fordDate);
                break;
            }
            if (line.EndsWith("Chevy")) {
                var chevyDate = DateTime.Parse(line.Substring(0, 19));
                Console.WriteLine("Chevy Date: {0}", chevyDate);
                chevyFound = true;
            }
        }
    }
