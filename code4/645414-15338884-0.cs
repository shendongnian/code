     protected override void OnPaint(PaintEventArgs e)
        {
            if (ImageForBackGround != null)
            {
               e.Graphics.DrawImage(ImageForBackGround, new Point(0, 0));
               this.SetStyle(ControlStyles.Opaque, true);
               
            }
        }
