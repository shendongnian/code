    public static string ReplaceAll(string input, string[] words)
        {
            string wordlist = string.Join("|", words);
            Regex rx = new Regex(wordlist, RegexOptions.Compiled);
            return rx.Replace(input, m => "");
        }
