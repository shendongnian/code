    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public RichTextBox RichTextBox1 { get { return richTextBox1; } }
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }
    }
