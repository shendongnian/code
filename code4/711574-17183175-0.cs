    public partial class Form2 : Form
    {
        private Form1 f;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            f = new Form1
                    {
                        Visible = false
                    };
            int x = f.X;
        }
    }
