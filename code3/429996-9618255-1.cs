    static void Main(string[] args)
            {
                var text = "Hello @Sunil you are going to work on #Desktop which has a priority of !1";
                var devPattern = new Regex(@"\@([^\s]+)");
                var teamPattern = new Regex(@"#([^\s]+)");
                var priorityPattern = new Regex(@"\!([0-9]+)");
                
                var team = ExtractValue(text, teamPattern);
                var dev = ExtractValue(text, devPattern);
                var priority = ExtractValue(text, priorityPattern);
            }
            private static string ExtractValue(string input, Regex regex)
            {
                return regex.IsMatch(input) ? regex.Match(input).Groups[1].ToString() : null;
            }
