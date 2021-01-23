    protected override void OnKeyDown(KeyEventArgs e) {
      if (Control.ModifierKeys == Keys.Control) {
        MessageBox.Show("I am pressing control.");
      }
      base.OnKeyDown(e);
    }
