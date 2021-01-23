    public class GameForm
    {
        private GameWorld _gw;
        public GameForm()
        {
            InitializeComponent();
        }
        public GameForm(GameWorld gw) : this()
        {
            _gw = gw;
        }
    }
