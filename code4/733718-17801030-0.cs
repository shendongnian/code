    private int SplitWords(string fbStatus)
        {
            int splitWords = fbStatus.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Count();
            label_totalwordcount.Text = splitWords.ToString();
            return splitWords;
        }
