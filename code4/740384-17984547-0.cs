string input = "txt ( apple , orange) txt txt txt ( hello, hi ) txt txt txt txt";
List<string> Options = new List<string>();
Regex regexHelpingWord = new Regex(@"\((.+?)\)");
foreach (Match m in regexHelpingWord.Matches(input))
{
    string words = Regex.Replace(m.ToString(), @"[()]", "");
    Regex regexSplitComma = new Regex(@"\s*,\s*");
    foreach (string word in regexSplitComma.Split(words))
    {
        Options.Add(word.Trim());
    }
}
