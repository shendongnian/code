    private Bitmap bb;
    void Control_OnResize(object sender, EventArgs e) {
      this.bb = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
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
