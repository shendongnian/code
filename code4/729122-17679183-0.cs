    private static List<string> wordsToRemove =
        "DE DA DAS DO DOS AN NAS NO NOS EM E A AS O OS AO AOS P LDA AND".Split(' ').ToList();
    
    public static string StringWordsRemove(string stringToClean)
    {
        return string.Join(" ", stringToClean.Split(' ').Except(wordsToRemove));
    }
