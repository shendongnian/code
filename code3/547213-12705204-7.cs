    LayerControl lc = new LayerControl(100, 100);
    lc.Location = new Point(0, 0);
    lc.DrawRectangle();
    LayerControl lc2 = new LayerControl(100, 100);
    lc2.Location = new Point(0, 0);
    lc2.DrawCircles();
    LayerControl lc3 = new LayerControl(100, 100);
    lc3.Location = new Point(0, 0);
    lc3.Image = new Bitmap(@"<Image Path>");
    // adding control
    this.Controls.Add(dc);
    this.Controls.Add(dc2);
    this.Controls.Add(dc3);
