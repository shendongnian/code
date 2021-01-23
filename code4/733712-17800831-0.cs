    private void SplitWords(string fbStatus)
    {
         int splitWords = fbStatus.Split(new char[] { ' ' },
         StringSplitOptions.RemoveEmptyEntries).Count();
    }
