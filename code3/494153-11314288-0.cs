        using System;
        using System.Drawing;
        using System.Windows.Forms;
        
        namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                private Pen _pen;
                
                private bool _mouseDown;
                private int _startX;
                private int _startY;
                
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    _pen = new Pen(Color.Black);
                }
        
                private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
                {
                    _mouseDown = true;
        
                    _startX = e.X;
                    _startY = e.Y;
                }
        
                private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
                {
                    _mouseDown = false;
                }
        
                private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
                {
                    if (_mouseDown)
                    {
                        using (var graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.DrawLine(_pen, _startX, _startY, e.X, e.Y);
                            _startX = e.X;
                            _startY = e.Y;
                        }
                        pictureBox1.Invalidate();
                    }
                }
        
            }
        }
