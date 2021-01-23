    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
    
                timer1.Enabled = true;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Enabled = false;
    
                int d;
    
                for (d = 0; d <= 100; d++)
                    progressBar1.Value = d;
    
                Hide();
    
                new Form1().Show();
            }
        }
    }
