    public class PlayerSettings
    {
        public List<String> Players = new List<String>();
        public void Name(String input)
        {
            Players.Add(input);
        }
        public IEnumerable<String> Names()
        {
            foreach (string Player in Players)
            {
                yield return Player;
            }
        }
    }
