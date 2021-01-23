     private Bitmap _backBuffer;
     private void Form1_Paint(object sender, PaintEventArgs e)
     {
          if (_backBuffer == null)
            {
                _backBuffer = new Bitmap(Form1.Width, Form1.Height, PixelFormat.Format32bppRgb);
            }
            Graphics g = Graphics.FromImage(_backBuffer);
           
            g.SmoothingMode = SmoothingMode.HighQuality;
           
            drawSomething(g);
            //Copy the back buffer to the screen
            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
            Form1.BackgroundImage = _backBuffer;
     }
