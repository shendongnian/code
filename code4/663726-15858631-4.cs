      public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
            }
          
            private void Form1_Load(object sender, EventArgs e)
            {
                Bitmap bmp = new Bitmap(@"C:\Users\Ali\Desktop\1.png");
                int w = bmp.Width;
                int h = bmp.Height;
                Lst_Data lastpointcolor = new Lst_Data() ;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color c = bmp.GetPixel(x, y);
                        if (c.A != Color.Transparent.A)
                        {
                            if (lastpointcolor.color.A == Color.Transparent.A)
                            {
                                bmp.SetPixel(lastpointcolor.point.X, lastpointcolor.point.Y, Color.Red);
                            }
                        }
                        lastpointcolor = new Lst_Data() { point = new Point(x, y), color = bmp.GetPixel(x, y) };
                    }
                }
    
                for (int y = h-1; y > 0; y--)
                {
                    for (int x = w-1; x > 0; x--)
                    {
                        Color c = bmp.GetPixel(x, y);
                        if (c.A != Color.Transparent.A)
                        {
                            if (lastpointcolor.color.A == Color.Transparent.A)
                            {
                                bmp.SetPixel(lastpointcolor.point.X, lastpointcolor.point.Y, Color.Red);
                            }
                        }
                        lastpointcolor = new Lst_Data() { point = new Point(x, y), color = bmp.GetPixel(x, y) };
                    }
                }
                pictureBox1.Image = bmp;
            }
        }
        public struct Lst_Data
        {
            public Point point;
            public Color color;
        }
    }
