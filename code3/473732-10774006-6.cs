    string result = r.Replace(line, new MatchEvaluator(replacementMethod));
    public string replacementMethod(Match match)
    {
       return "?????";
    }
