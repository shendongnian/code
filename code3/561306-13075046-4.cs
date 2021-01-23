    public partial class Form1 : Form
    {
        private Button[] btns;
        public Form1()
        {
            InitializeComponent();
            btns = new Button[] { button2, button3 };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var btn in btns)
            {
                btn.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var btn in btns)
            {
                if (!btn.Enabled)
                {
                    btn.Enabled = true;
                    return;
                }
            }
        }
    }
