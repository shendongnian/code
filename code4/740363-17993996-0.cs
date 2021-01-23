    static class Program
    {
        static void Main(string[] args)
        {
            string subject = "Subject>memberName1>memberName2>member>Name3>EndSubject";
            var result = Find(subject, true).ToList();
            result.ForEach(item => {
                Console.WriteLine(item);
            });
        }
        private static IEnumerable<string> Find(string subject, bool toggle)
        {
            var temp = Regex.Matches(subject, toggle ? @"(?<=>)(?>([\w]*>[\w]*))(?=>)" : @"[\w]*")
                .Cast<Match>()
                .ToList();
            return temp.SelectMany(m =>
                temp
                .Select(i => i.Value)
                .Union(Find(m.Value, !toggle)))
                .Where(s => !String.IsNullOrEmpty(s))
                .Distinct();
        }
    }
