    Bitmap bmp = new Bitmap();
    
    int X = e.X - bmp.Width/2;
    int Y = e.Y - bmp.Height/2;
    // créer et initialiser le BufferedGraphics
    BufferedGraphics bg =
    BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(),
    ClientRectangle);
    Graphics g = bg.Graphics;
    
    g.Clear(SystemColors.Control);
    g.DrawImage(bmp, new Point(X, Y));
    
    bg.Render();
    g.Dispose(); 
    bg.Dispose();
    //save bmp as file 
