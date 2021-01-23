    private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
      if (this.ActiveControl is TextBox) {
        Clipboard.SetText(((TextBox)this.ActiveControl).SelectedText);
      } else {
        // do your menu Edit-Copy code here
      }
    }
    private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
      if (this.ActiveControl is TextBox) {
        ((TextBox)this.ActiveControl).SelectedText = Clipboard.GetText();
      } else {
        // do you menu Edit-Paste code here
      }
    }
