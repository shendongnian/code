    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Bitmap bmp = new Bitmap(100, 13, e.Graphics);
        bmp.Save(<SomefilePath.png>);
        //following code works good
        progressRenderer.SetParameters("PROGRESS", 11, 2);
        progressRenderer.DrawBackground(e.Graphics, new Rectangle(125, 5, 100, 13));
    }
