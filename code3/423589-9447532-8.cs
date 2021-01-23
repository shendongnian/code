    public partial class Form1 : Form
    {
        public static CheckedListBox PlayerList { get; private set; }
        public Form1()
        {
            InitializeComponent();
            PlayerList = listPlayers;
        }
        
        ...
    }
