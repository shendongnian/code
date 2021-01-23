    public partial class Form1 : Form
    {
        public static CheckComboBox PlayerList { get; private set; }
        public Form1()
        {
            InitializeComponent();
            PlayerList = listPlayers;
        }
        
        ...
    }
