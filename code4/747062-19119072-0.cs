    public class FoldFinder
    {
        public static FoldFinder Instance { get; private set; }
        static FoldFinder()
        {
            Instance = new FoldFinder();
        }
        public List<SectionPosition> Find(string code, List<SectionDelimiter> delimiters, int start = 0,
            int end = -1)
        {
            List<SectionPosition> positions = new List<SectionPosition>();
            Stack<SectionStackItem> stack = new Stack<SectionStackItem>();
            int regexGroupIndex;
            bool isStartToken;
            SectionDelimiter matchedDelimiter;
            SectionStackItem currentItem;
            Regex scanner = RegexifyDelimiters(delimiters);
            foreach (Match match in scanner.Matches(code, start))
            {
                // the pattern for every group is that 0 corresponds to SectionDelimter, 1 corresponds to Start
                // and 2, corresponds to End.
                regexGroupIndex = 
                    match.Groups.Cast<Group>().Select((g, i) => new {
                        Success = g.Success,
                        Index = i
                    })
                    .Where(r => r.Success && r.Index > 0).First().Index;
                matchedDelimiter = delimiters[(regexGroupIndex - 1) / 3];
                isStartToken = match.Groups[regexGroupIndex + 1].Success;
                if (isStartToken)
                {
                    stack.Push(new SectionStackItem()
                    {
                        Delimter = matchedDelimiter,
                        Position = new SectionPosition() { Start = match.Index }
                    });
                }
                else
                {
                    currentItem = stack.Pop();
                    if (currentItem.Delimter == matchedDelimiter)
                    {
                        currentItem.Position.End = match.Index + match.Length;
                        positions.Add(currentItem.Position);
                        // if searching for an end, and we've passed it, and the stack is empty then quit.
                        if (end > -1 && currentItem.Position.End >= end && stack.Count == 0) break;
                    }
                    else
                    {
                        throw new Exception(string.Format("Invalid Ending Token at {0}", match.Index)); 
                    }
                }
            }
            if (stack.Count > 0) throw new Exception("Not enough closing symbols.");
            return positions;
        }
        public Regex RegexifyDelimiters(List<SectionDelimiter> delimiters)
        {
            return new Regex(
                string.Join("|", delimiters.Select(d =>
                    string.Format("(({0})|({1}))", d.Start, d.End))));
        }
    }
    public class SectionStackItem
    {
        public SectionPosition Position;
        public SectionDelimiter Delimter;
    }
    public class SectionPosition
    {
        public int Start;
        public int End;
    }
    public class SectionDelimiter
    {
        public string Start;
        public string End;
    }
