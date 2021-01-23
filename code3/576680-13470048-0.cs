    public delegate void RequestLabelTextChangeDelegate(string newText);
    public partial class Form2 : Form
    {
        public event RequestLabelTextChangeDelegate RequestLabelTextChange;
        private void button1_Click(object sender, EventArgs e)
        {
            if (RequestLabelTextChange != null)
            {
                RequestLabelTextChange("Bye");
            }
        }        
        
        public Form2()
        {
            InitializeComponent();
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.RequestLabelTextChange += f2_RequestLabelTextChange;
        }
        void f2_RequestLabelTextChange(string newText)
        {
            label1.Text = newText;
        }
    }  
