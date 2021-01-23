    using (Graphics g = this.CreateGraphics())
    {
        var points = myFont.SizeInPoints;
        var pixels = points * g.DpiX / 72;
        MessageBox.Show("myFont size in pixels: " + pixels);
    }
