    public static class HymnReader
    {
        public static IEnumerable<Hymn> ReadHymns(string file)
        {
            var lines = File.ReadAllLines(file);
            var hymns = new List<Hymn>();
            Hymn hymn = null;
            List<string> verse = null;
            foreach (var line in lines)
            {
                string text;
                switch (ParseLine(line, out text))
                {
                    case LineType.Title:
                        hymn = new Hymn(text);
                        hymns.Add(hymn);
                        break;
                    case LineType.Verse:
                        if (verse == null) verse = hymn.CreateVerse();
                        verse.Add(text);
                        break;
                    default:
                        verse = null;
                        break;
                }
            }
            return hymns;
        }
        private static LineType ParseLine(string line, out string text)
        {
            text = "";
            if (string.IsNullOrWhiteSpace(line)) return LineType.Unkown;
            var array = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length < 2) return LineType.Unkown; 
            int n;
            if (int.TryParse(array[0], out n))
            {
                text = string.Join(" ", array, 1, array.Length - 1).Trim();
                return LineType.Title;
            }
            text = string.Join(" ", array).Trim();
            return LineType.Verse;
        }
        private enum LineType
        {
            Unkown,
            Title,
            Verse
        }
    }
