    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public RichTextBox PrintCtrl1 { get { return richTextBoxPrintCtrl1; } }
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }
    }
