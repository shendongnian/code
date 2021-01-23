    protected override void OnPaint(PaintEventArgs e)
    {
       Bitmap bm = new Bitmap(@"C:\Alan\University\111.jpg");
    
       // Draw using this   
       e.Graphics.DrawImage(bm,60,60);
    
       base.OnPaint(e);
    }
