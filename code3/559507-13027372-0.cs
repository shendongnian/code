    public partial class Form1 : Form
    {
    TextBox[] tb;
        public Form1()
        {
            InitializeComponent();
            tb = new TextBox[2];
            //...
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tb[0].Text);
        }
    }
