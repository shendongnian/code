    public class FindInDirectory
    {
        public class Match
        {
            public string Pattern { get; set; }
            public string Directory { get; set; }
            public MatchCollection Matches { get; set; }
        }
        public static List<FindInDirectory.Match> Search(string directory, string searchPattern, List<string> patterns)
        {
            //find all file locations
            IEnumerable<string> files = System.IO.Directory.EnumerateFiles(directory, searchPattern, System.IO.SearchOption.AllDirectories);
            //load all text into memory for MULTI-PATERN
            //this greatly increases speed, but it requires a ton of memory!
            Dictionary<string, string> contents = files.ToDictionary(f => f, f => System.IO.File.ReadAllText(f));
            List<FindInDirectory.Match> directoryMatches = new List<Match>();
            foreach (string pattern in patterns)
            {
                directoryMatches.AddRange
                (
                    contents.Select(c => new Match
                    {
                        Pattern = pattern,
                        Directory = c.Key,
                        Matches = Regex.Matches(c.Value, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline)
                    })
                    .Where(c => c.Matches.Count > 0)//switch to > 1 when program directory is same or child of search
                );
            };
            return directoryMatches;
        }
    }
