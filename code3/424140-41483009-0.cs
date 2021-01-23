    public partial class Form1 : Form
    {
        private static Form1 inst;
        public static Form1 GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new Form1();
                }
                return inst;
            }
        }
        public Form1()
        {
            InitializeComponent();
            inst = this;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2.GetForm.Show();
            this.Hide();
        }
    }
------------------------------------------------------
    public partial class Form2 : Form
    {
        private static Form2 inst;
        public static Form2 GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new Form2();
                return inst;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.GetForm.Show();
            this.Hide();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.GetForm.Show();
        }
    }
