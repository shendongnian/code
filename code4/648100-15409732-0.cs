    class Program
    {
        static void Main(string[] args)
        {
            var g = new Generator();
            IEnumerable<string> passwords = new List<string>();
            var startTime = DateTime.Now;
            passwords = g.GetPassword().ToList();
        }
    }
    class Generator
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        string randomCharsList;
        const int length = 8;
        const int randomLength = 8000;
        const string listOfCharacters = "abcdefghijklmnopqrstuvwxyz";
        public Generator()
        {
            CreateRandom();
        }
        private void CreateRandom()
        {
            var randomChars = new StringBuilder();
            string password = string.Empty;
            for (int i = 0; i < randomLength + length; i++)
            {
                var random = new Random(i * Guid.NewGuid().ToByteArray().First());
                int x = random.Next(0, listOfCharacters.Length);
                randomChars.Append(listOfCharacters[x]);
            }
            randomCharsList = randomChars.ToString();
        }
        public IEnumerable<string> GetPassword()
        {
            int pos;
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).Milliseconds < 1)
            {
                pos = r.Next(randomLength);
                yield return randomCharsList.Substring(pos, length);
            }
        }
    }
