    public class PlayerSettings
    {
        public List<string> Players = new List<string>();
        public void Name(string input)
        {
            Players.Add(input);
        }
        public IEnumerable<string> Name()
        {
            return Players;
        }
    }
