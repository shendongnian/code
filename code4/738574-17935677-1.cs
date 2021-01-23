    class MyReplacer {
       public string ReplaceSpaces(Match m)
       {
            return m.Value.Replace(" ", "_");
       }
    void replacingMethod() {
       ...
       Regex re = new Regex("<.*>");
		
       MyReplacer r = new MyReplacer();
       // Assign the replace method to the MatchEvaluator delegate.
       MatchEvaluator myEvaluator = new MatchEvaluator(r.ReplaceSpaces);
       // Replace matched characters using the delegate method.
       sInput = re.Replace(sInput, myEvaluator);
    }
