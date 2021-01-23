    public enum Languages
    {
        Ger, Eng, Fra, Ita, Rus
    }
    public class Player
    {
        public string ID { get; private set; }
        private Languages[] Languages;
        public Player(string ID, params Languages[] LangList)
        {
            this.ID = ID;
            this.Languages = LangList;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player PlayerA = new Player("Player A", Languages.Ger, Languages.Eng);
        }
    }
