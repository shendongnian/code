    public class TournamentMain
    {
        public int ID { get; set; }
        public string name { get; set; }
        public double buy_in { get; set; }
        public double re_buy { get; set; }
        public double add_on { get; set; }
        public int blindindex { get; set; }
        public int placeindex { get; set; }
        public int playerindex { get; set; }
        public ObservableCollection<Blind> blinds { get; set; }
        public ObservableCollection<Player> players { get; set; }
        public ObservableCollection<Place> places { get; set; }
        public ObservableCollection<Paidplace> paidplaces {get; set;} 
        public TournamentMain() 
        {
            ID = 0;
            blindindex = 1;
            placeindex = 1;
            playerindex = 1;
            players = new ObservableCollection<Player>();
            places = new ObservableCollection<Place>();
            blinds = new ObservableCollection<Blind>();
            paidplaces = new ObservableCollection<Paidplace>();
       } 
