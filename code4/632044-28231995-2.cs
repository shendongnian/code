    //FormMain.cs
    private const float DisplayRatio = 6;
    private Bitmap _bmpDisp; //use an in-memory bitmap to Persistent graphics
    private Graphics _grpDisp4Ctl;
    private Graphics _grpDisp4Bmp;
    private Point _ptOldDsp;
    private void FormMain_Shown(object sender, EventArgs e)
    {
        _grpDisp4Ctl = CreateGraphics();
        _grpDisp4Ctl.SetHighQulity();
        _bmpDisp = new Bitmap(ClientSize.Width, ClientSize.Height);
        _grpDisp4Bmp = Graphics.FromImage(_bmpDisp);
        _grpDisp4Bmp.SetHighQulity();
        _ptOldDsp = new Point(
            (int)((MousePosition.X - SystemInformation.VirtualScreen.Left) / DisplayRatio),
            (int)((MousePosition.Y - SystemInformation.VirtualScreen.Top) / DisplayRatio)
        );
    }
    private void UpdateDisplay(MouseHookEvent mhep) //your implement
    {        
        var ptNew = mhep.Position;
        ptNew.Offset(new Point(-SystemInformation.VirtualScreen.Left, -SystemInformation.VirtualScreen.Top));
        ptNew.X = (int)(ptNew.X / DisplayRatio);
        ptNew.Y = (int)(ptNew.Y / DisplayRatio);
        _grpDisp4Ctl.DrawLine(Pens.White, _ptOldDsp, ptNew); //draw smooth lines to mem and ui
        _grpDisp4Bmp.DrawLine(Pens.White, _ptOldDsp, ptNew);
        _ptOldDsp = ptNew;
    }
    private void FormMain_Paint(object sender, PaintEventArgs e)
    {
        // like vb6's auto redraw :)
        e.Graphics.DrawImage(_bmpDisp, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
    }
    //common.cs
    internal static void SetHighQulity(this Graphics g)
    {
        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    }
