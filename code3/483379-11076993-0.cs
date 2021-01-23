    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent(); 
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                button1.Text = "Hello World!";
            }
    
            private void button1_MouseHover(object sender, EventArgs e)
            {
                button1.Text = "Mouse Hover";
            }
    
            private void button1_MouseDown(object sender, MouseEventArgs e)
            {
                button1.Text = "Mouse Down";
            }
    
            private void button1_MouseUp(object sender, MouseEventArgs e)
            {
                button1.Text = "Mouse Up";
            }
    
            private void button1_MouseLeave(object sender, EventArgs e)
            {
                button1.Text = "Mouse Leave";      
            }      
        }    
    }
