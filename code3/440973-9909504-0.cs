    using(Bitmap b = new Bitmap(this.ClientSize.Width, this.ClientSize.Height)) {
        using(Graphics g = Graphics.FromImage(b)) {
            g.CopyFromScreen(this.PointToClient(Point.Empty), Point.Empty, this.ClientSize);
        }
    
        // Your form is now rendered into b.
    }
