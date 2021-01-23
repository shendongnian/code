    public partial class Form1 : Form
    {
        private Button[] btns;
        public Form1()
        {
            InitializeComponent();
            btns = new Button[] { button2, button3 };
        }
        private void setButtonEnabled(bool enabled)
        {
            foreach (var btn in btns)
            {
               btn.Enabled = enabled;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            setButtonEnabled(false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            setButtonEnabled(true);
        }
    }
