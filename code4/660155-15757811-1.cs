    class GameClass
    {
        public enum Genre
        {
            RPG,
            MMO,
            RTS,
            Other
        }
        public enum Platform
        {
            Windows,
            Linux,
            MAC
        }
        private string gameName;
        private string developer;
        private string publisher;
        private DateTime releaseDate;
        private Platform platform;
        private Genre genre;
        private int numPlayers;
        private string description;
        private Bitmap picture;
        public string GameName
        {
            get
            {
                return gameName;
            }
            set
            {
                gameName = value;
            }
        }
        public Genre GameGenre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }
        //... Other get set methods
    }
