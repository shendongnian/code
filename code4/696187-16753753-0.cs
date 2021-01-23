    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 f2 = null;
        private void button1_Click(object sender, EventArgs e) // first I click here
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new Form2();
                f2.Show();
            }
            else 
            {
                ActivateForm2();
            }
        }
        private void button2_Click(object sender, EventArgs e) // then here, to activate it
        {
            ActivateForm2();
        }
        private void ActivateForm2()
        {
            if (f2 != null && !f2.IsDisposed)
            {
                if (f2.WindowState == FormWindowState.Minimized)
                {
                    f2.WindowState = FormWindowState.Normal;
                }
                f2.Activate();
            }
        }
    }
