    [Serializable]
    public class HighScoreData
    {
        public string PlayerName;
        public int Score;
        public int Level;
    }
    [Serializable]
    public class HighScoresCollection
    {
        List<HighScoreData> HighScores; 
    }
