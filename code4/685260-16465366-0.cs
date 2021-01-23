    public partial class Form1 : Form
    {
        private Form2 f2 = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                string a = textBox1.Text;
                f2 = new Form2(a);
                f2.Show();
            }
            else 
            {
                if (f2.WindowState == FormWindowState.Minimized)
                {
                    f2.WindowState = FormWindowState.Normal;
                }
                f2.Activate();
            }
        }
    }
