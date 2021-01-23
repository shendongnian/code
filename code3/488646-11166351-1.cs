    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            int x = 250;
            int y = 250;
    
            public Form1()
            {
                InitializeComponent();
            }
        
            private void button1_Click(object sender, EventArgs e)
           {
                button1.Visible = false;
                Pen main = new Pen(Color.Black);
                this.CreateGraphics().DrawRectangle(main, vars.x, vars.y, 2, 2);
           }
        }
    }
