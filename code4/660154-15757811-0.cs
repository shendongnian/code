    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameClass gameclass = new GameClass();
            gameclass.GameName = "Name of Game";
            gameclass.GameGenre = GameClass.Genre.RPG;
        }
    }
