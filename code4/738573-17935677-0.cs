    class MyReplacer {
       public string Replace(Match m)
       {
            return m.Value.Replace(" ", "_");
       }
    void replacingMethod() {
       Regex r = new Regex("<.*>");
		
       MyReplacer r = new MyReplacer();
       // Assign the replace method to the MatchEvaluator delegate.
       MatchEvaluator myEvaluator = new MatchEvaluator(r.Replace);
       // Replace matched characters using the delegate method.
       sInput = r.Replace(sInput, myEvaluator);
    }
