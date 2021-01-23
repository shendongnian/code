    private SelectionTool _SelectPanel = null;
    private void Form1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == System.Windows.Forms.MouseButtons.Left) {
        if (_SelectPanel == null)
          _SelectPanel = new SelectionTool(this, e.Location);
      }
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e) {
      if (_SelectPanel != null) {
        _SelectPanel.Dispose();
        _SelectPanel = null;
      }
    }
