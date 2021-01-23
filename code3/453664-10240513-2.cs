    public partial class MainForm : Form
    {
        public static MainForm Instance = null;
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public SomeMethod()
        {
        }
    }
