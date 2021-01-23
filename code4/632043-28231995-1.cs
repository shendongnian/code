    private Bitmap _bmpDisp; //use an in-memory bitmap to Persistent graphics
    private Graphics _grpDisp4Ctl;
    private Graphics _grpDisp4Bmp;
    private void FormMain_Shown(object sender, EventArgs e)
    {
        _grpDisp4Ctl = CreateGraphics();
        _grpDisp4Ctl.SetHighQulity();
        _bmpDisp = new Bitmap(ClientSize.Width, ClientSize.Height);
        _grpDisp4Bmp = Graphics.FromImage(_bmpDisp);
        _grpDisp4Bmp.SetHighQulity();
    }
    private void UpdateDisplay(MouseHookEvent mhep) //your implement
    {        
        var ptNew = mhep.Position;
        ptNew.Offset(new Point(-SystemInformation.VirtualScreen.Left, -SystemInformation.VirtualScreen.Top));
        _grpDisp4Ctl.FillRectangle(Brushes.White, ptNew.X / DisplayRatio, ptNew.Y / DisplayRatio, 1, 1); //instant draw to ui 
        _grpDisp4Bmp.FillRectangle(Brushes.White, ptNew.X / DisplayRatio, ptNew.Y / DisplayRatio, 1, 1); //draw to in-memory bitmap
    }
    private void FormMain_Paint(object sender, PaintEventArgs e)
    {
        // like vb6's auto redraw :)
        e.Graphics.DrawImage(_bmpDisp, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
    }
    
    internal static void SetHighQulity(this Graphics g)
    {
        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    }
