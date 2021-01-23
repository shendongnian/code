    public partial class MainClass : Form
        {
            public MainClass()
            {
                InitializeComponent();
                rich = this.richTextBox1;  //assign in the constructor
            }
            static public RichTextBox rich;
        }
