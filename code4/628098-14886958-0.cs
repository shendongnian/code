    public class Program
    {
        [XmlRoot("root")]
        public class Team
        {
            private List<Player> players = new List<Player>();
            [XmlElement("player")]
            public List<Player> Players { get { return this.players; } set { this.players = value; } }
            // serializer requires a parameterless constructor class
            public Team() { }
        }
        
        public class Player
        {
            private List<int> verticalLeaps = new List<int>();
            [XmlElement]
            public string FirstName { get; set; }
            [XmlElement]
            public string LastName { get; set; }
            [XmlElement]
            public List<int> vertLeap { get { return this.verticalLeaps; } set { this.verticalLeaps = value; } }
            // serializer requires a parameterless constructor class
            public Player() { }
        }
        static public void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.WritePlayertoDatabase();
            myProgram.ReadPlayerDatabase();
        }
        public void WritePlayertoDatabase()
        {
            Player p1 = new Player() { FirstName = "dwight", LastName = "howard", vertLeap = new List<int>() { 1, 2, 3 } };
            Player p2 = new Player() { FirstName = "dwight", LastName = "howard", vertLeap = new List<int>() { 1 } };
            Team players = new Team();
            players.Players.Add(p1);
            players.Players.Add(p2);
            XmlSerializer serializer = new XmlSerializer(typeof(Team));
            using (TextWriter textWriter = new StreamWriter(@"C:\temp\temp.txt"))
            {
                serializer.Serialize(textWriter, players);
                textWriter.Close();
            }
        }
        public void ReadPlayerDatabase()
        {
            Team myTeamData = new Team();
            XmlSerializer deserializer = new XmlSerializer(typeof(Team));
            using (TextReader textReader = new StreamReader(@"C:\temp\temp.txt"))
            {
                myTeamData = (Team)deserializer.Deserialize(textReader);
                textReader.Close();
            }
        }
    }
