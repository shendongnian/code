    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Derpy merp = new Derpy();
                merp.OnDerp += new EventHandler(herp);
                
    
            }
            private void herp(object sender, EventArgs e)
            {
    
            }
 
    
        }
    }
