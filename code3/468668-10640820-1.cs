    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);
            this.Load += new EventHandler(Form1_Load);
            
        }
        void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                ShowInTaskbar = true;
            }
        }
    }
