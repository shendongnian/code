    public class PlayerSettings
    {
        private List<string[]> Players = new List<string[]>();
        public void Name(string input)
        {`enter code here`
            string[] addname = new string[1];
            addname[0] = input;
            Players.Add(addname);
        }
        public string[] Name()
        {
            List<string> result = new List<string>();
            foreach (string[] Player in Players)
            {
                result.AddRange(Player);
            }
            return result.ToArray();
        }
    }
