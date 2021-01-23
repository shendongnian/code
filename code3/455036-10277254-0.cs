    public Bitmap Draw()
    {
       var bitmap = new Bitmap(width,height, PixelFormat.Format32bppArgb);
       var graphics = Graphics.FromImage(bitmap);
       graphics.SmoothingMode = SmoothingMode.AntiAlias;
       graphics.FillRectangle(new SolidBrush(Color.Tomato), 10, 10, 100, 100);
    }
    this.pictureBox1.Image = new PieChart().Draw();
