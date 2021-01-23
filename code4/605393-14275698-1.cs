    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                bool isTrue = false;
    
                if (isTrue == true)
                {
                    g.DrawLine(Pens.Red, new Point(0, 50), new Point(150, 50));
                }
                else
                {
                    g.DrawLine(Pens.Blue, new Point(0, 50), new Point(300, 50));
                }
    
                g.Dispose();
            }
        }
    }
