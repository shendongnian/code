    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
      {
        var clipboard = Clipboard.GetText();
        if (Directory.Exists(clipboard))
          textBox1.Text = clipboard;
      }
    }
