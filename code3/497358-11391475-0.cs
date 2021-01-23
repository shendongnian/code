    public class PlayerSettings
    {
        public List<string> Players = new List<string>();
        public void Name(string input)
        {
            Players.Add(input);
        }
        public string[] Name()
        {
            return Players.ToArray();
        }
    }
