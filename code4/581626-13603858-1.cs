    static class CustomReplacer
    {
        public static string Replace(string input)
        {
            int i = 0;
            return Regex.Replace(input, "/", m => i++ < 2 ? "_" : "");
        }
    }
    var replaced = CustomReplacer.Replace("A/ABC/N/ABC/123");
