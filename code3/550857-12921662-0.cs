    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      e.Graphics.FillRectangle(Pens.Black, 
           new Rectangle(0, this.ClientSize.Height - 32, this.ClientSize.Width, 32));
      bool isGlassEnabled = false;
      Margins margin;
      margin.Top = 0;
      margin.Left = 0;
      margin.Bottom = 32;
      margin.Right = 0;
      DwmIsCompositionEnabled(out isGlassEnabled);
      if (isGlassEnabled) {
        DwmExtendFrameIntoClientArea(this.Handle, ref margin);
      }
    }
