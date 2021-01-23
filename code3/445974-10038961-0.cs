        public static void Main(string[] args)
        {
            string broken = @"
    <meals>
        <breakfast>
             Eggs and Toast
        </breakfast>
        <lunch>
             Salad and soup
        <lunch>
        <supper>
             Roast beef and potatoes
        </supper>
    </meals>";
            var pattern1 = "(?<open><(?<tag>[a-z]+)>)(.+?)(\\k<open>)";
            var re1 = new Regex(pattern1, RegexOptions.Singleline);
            String work = broken;
            Match match = null;
            do
            {
                match = re1.Match(work);
                if (match.Success)
                {
                    Console.WriteLine("Match at position {0}.", match.Index);
                    var tag = match.Groups["tag"].ToString();
                    Console.WriteLine("tag: {0}", tag.ToString());
                    work = work.Substring(0, match.Index) +
                        match.Value.Substring(0, match.Value.Length - tag.Length -1) +
                        "/" +
                        work.Substring(match.Index + match.Value.Length - tag.Length -1);
                    Console.WriteLine("fixed: {0}", work);
                }
            } while (match.Success);
        }
