    class Program
    {
        static void Main(string[] args)
        {
            var code = $@"
                public static loremIpsum(): lorem {{
                    return {{
                        lorem: function() {{
                            return 'foo'
                        }},
                        ipsum: function() {{
                            return 'bar'
                        }},
                        dolor: function() {{
                            return 'buzz'
                        }}
                    }}
                }}".AutoTrim();
            Console.WriteLine(code);
        }
    }
    static class Extensions
    {
        public static string AutoTrim(this string code)
        {
            string newline = Environment.NewLine;
            var trimLen = code
                .Split(newline)
                .Skip(1)
                .Min(s => s.Length - s.TrimStart().Length);
            return string.Join(newline,
                code
                .Split(newline)
                .Select(line => line.Substring(Math.Min(line.Length, trimLen))));
        }
    }
