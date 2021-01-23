    protected override void OnPaint(PaintEventArgs e)
    {
        if (MemoryImage != null)
        {
            e.Graphics.DrawImage(MemoryImage, 0, 0);
            base.OnPaint(e);
        }
    }
