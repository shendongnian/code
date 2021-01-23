    protected override void OnKeyDown(KeyEventArgs e) {
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W) {
        picPaddle.Top -= 10;
      } else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S) {
        picPaddle.Top += 10;
      }
      base.OnKeyDown(e);
    }
