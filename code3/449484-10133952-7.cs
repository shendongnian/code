    public partial class Form1 : Form
    {
        pwn4g3 mainForm = new pwn4g3();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(mainForm.IsDisposed )   //Check that Form hasn't been destroyed
               mainForm = new pwn4g3();
            if(!mainForm.Visible)  //Make sure it is visible
                mainForm.Show();
            mainForm.TopMost = !mainForm.TopMost;
            this.BringToFront(); //To verify zorder of created form
        }
    }
