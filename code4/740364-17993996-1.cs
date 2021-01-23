    static class Program
    {
        static void Main(string[] args)
        {
            string prefix = ">";
            string suffix = ">";
            string subject =
                "Subject>memberName1>memberName2>member>Name3>EndSubject";
            var result = Find(subject, true, prefix, suffix).ToList();
            result.ForEach(item =>
            {
                Console.WriteLine(item);
            });
            /* The output is:
            memberName1>memberName2
            member>Name3                *match
            memberName1                 *match
            memberName2                 *match
            member
            Name3
             */
        }
        private static IEnumerable<string> Find(
            string subject,
            bool toggle,
            string prefix,
            string suffix)
        {
            var temp = Regex.Matches(subject, toggle ?
                @"(?<=" + prefix + @")(?>([\w]*(" + prefix + "|" + suffix + @")[\w]*))(?=" + suffix + ")" :
                @"[\w]*")
                .Cast<Match>()
                .ToList();
            return temp.SelectMany(m =>
                temp
                .Select(i => i.Value)
                .Union(Find(m.Value, !toggle, prefix, suffix)))
                .Where(s => !String.IsNullOrEmpty(s))
                .Distinct();
        }
    }
