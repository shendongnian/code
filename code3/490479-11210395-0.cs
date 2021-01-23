    public class SavedGame
    {
        public class Level
        {
            public int id;
            public int score;
        }
        
        [XmlElement()]
        public List<Level> level = new List<Level>();
    }
