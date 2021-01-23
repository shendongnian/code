    public partial class Form1 : Form
    {
        public delegate void DoWorkDelegate();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BeginInvoke(new DoWorkDelegate(DoWorkMethod));
        }
        public void DoWorkMethod()
        {
            //Do something
        }
    }
