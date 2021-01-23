    //First form
    public partial class SetupScreen : Form
    {
        Control myObject;
        public Battleship myBattleship;
        public SetupScreen()
        {
            InitializeComponent();
            //Create Class Object
            myBattleship = new Battleship();
            Form gameForm = new GameScreen(); // New form object
            gameForm.MyBattleship = myBattleship; // Set property
            gameForm.Show(); // Show form
        }
    }
    //Second form 
    public partial class GameScreen : Form
    {
        Control myObject;
        Battleship fredBattleship;
        public BattleShip MyBattleship { set; get; }
        public GameScreen()
        {
            InitializeComponent();
        }
    }
