    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (Owner == null) return; //Check to make sure there is an Owner
            if (Owner.GetType() == typeof(Form1))
                button1.Enabled = true;
            else if (Owner.GetType() == typeof(Form2))
                button2.Enabled = true;
        }
    }
