    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            Text = Program.FormTitle;
            base.OnLoad(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.FormTitle = "new form title";
            Text = Program.FormTitle;
            new Form2().Show();
        }
    }
 
