    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            someUserControl1.button1.Click += new EventHandler(button1_Click);
            someUserControl2.button1.Click += new EventHandler(button1_Click);
            someUserControl3.button1.Click += new EventHandler(button1_Click);
        }
        void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Control uc = btn.Parent;
            while (uc != null && !(uc is SomeUserControl))
            {
                uc = uc.Parent;
            }
            uc.BackColor = Color.Red;
            MessageBox.Show(uc.Name);
        }
    }
