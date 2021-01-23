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
                    Point pt1 = new Point(0, 50);
                    Point pt2 = new Point(200, 50);
                    
        
                    bool isTrue = true;
                    
                    if (isTrue == true)
                    {
                        g.DrawLine(Pens.Red, pt1, pt2);
        
                    }
                    else
                    {
                        g.DrawLine(Pens.Blue, pt1, pt2);
                    }
        
                    g.Dispose();          
                }
            }
        }
