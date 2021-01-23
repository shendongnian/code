    void element_LocationChanged(object sender, EventArgs e)
    {
          canvas.Invalidate();
    }
    void canvas_Paint(object sender, PaintEventArgs e)
    {
          if (element != null)
          {
                Bitmap bmp = new Bitmap(element.Display);
                Pen p = new Pen(Color.FromArgb(128, 128, 128), 1);
                e.Graphics.DrawImage(bmp, element.Location);
                e.Graphics.DrawRectangle(p, 
                     element.Location.X, element.Location.Y, 
                     bmp.Width, bmp.Height);
          }
    }
