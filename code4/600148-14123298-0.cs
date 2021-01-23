    void PutPixel(Graphics g, int x, int y, Color c)
    {
          Bitmap bm = new Bitmap(1, 1);
          bm.SetPixel(0, 0, Color.Red);
          g.DrawImageUnscaled(bm, x, y);
    }
     
    private void Form1_Paint(object sender, PaintEventArgs e)
    {  
          Graphics myGraphics = e.Graphics;
     
          myGraphics.Clear(Color.White);
          double radius = 5;
          for (int j = 1; j <= 25; j++)
          {
                radius = (j + 1) * 5;
                for (double i = 0.0; i < 360.0; i += 0.1)
                {
                    double angle = i * System.Math.PI / 180;
                    int x = (int)(150 + radius * System.Math.Cos(angle));
                    int y = (int)(150 + radius * System.Math.Sin(angle));
               
                    PutPixel(myGraphics, x, y, Color.Red);
                }
          }
          myGraphics.Dispose();
    }
