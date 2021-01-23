    private Bitmap bb;
    protected override void OnResize(EventArgs e) {
      this.bb = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
      this.InitBackBuffer();
    }
    private void InitBackBuffer() {
      using (var g = Graphics.FromImage(this.bb)) {
        // do any of the "non dissapearing line" drawing here
      }
    }
    private void TicTacToe_MouseClick(object sender, MouseEventArgs e)
      using (Graphics g = Graphics.FromImage(this.bb))
        g.DrawEllipse(this.penRed, this.Rectangle);
      this.Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      e.Graphics.DrawImageUnscaled(this.bb);
    }
