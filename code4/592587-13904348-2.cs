    var charSet = new HashSet<char>("abcde\x015f" + Regex.Unescape("\u0066"));
    string input = "abc  defş aaa xyz";
    var words =  input.Split()
                    .Where(s => !String.IsNullOrWhiteSpace(s))
                    .Where(s => s.All(c => charSet.Contains(c)))
                    .ToList();
