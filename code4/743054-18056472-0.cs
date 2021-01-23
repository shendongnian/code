    class Program
    {
        static void Main(string[] args)
        {
            var input = "text0<%code0%>text1<%code1%><%%>text3";
            List<string>
                text = new List<string>(),
                code = new List<string>();
            var current = 0;
            Regex.Matches(input, @"<%.*?%>")
                .Cast<Match>()
                .ToList().ForEach(m =>
                {
                    text.Add(input.Substring(current, m.Index - current));
                    code.Add(m.Value);
                    current = m.Index + m.Length;
                    if(!m.NextMatch().Success)
                        text.Add(input.Substring(current, input.Length - current));
                });
        }
    }
