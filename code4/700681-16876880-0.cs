    public partial class Form1 : Form
    {
        Form2 F2 = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (F2 == null || F2.IsDisposed)
            {
                F2 = new Form2();
                F2.Show();
            }
            else
            {
                if (F2.WindowState == FormWindowState.Minimized)
                {
                    F2.WindowState = FormWindowState.Normal;
                }
                F2.Activate();
            }
        }
    }
