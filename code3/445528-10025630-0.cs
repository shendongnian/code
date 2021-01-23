        int w = this.Width; 
        int h = this.Height; 
        Size sz = this.Size; 
        Point loc = this.Location; 
        Hide();
        System.Threading.Thread.Sleep(500);
        using (Image b = new Bitmap(w, h)) 
        { using (Graphics g = Graphics.FromImage(b)) 
        { 
            g.CopyFromScreen(loc, new Point(0, 0), sz); }
          
            Image x = new Bitmap(b);
            this.BackgroundImage = x;
        } 
        Show();
