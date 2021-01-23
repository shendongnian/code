    private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e) {
      ToolStripSplitButton tsb = (ToolStripSplitButton)sender;
      string text = tsb.DropDownItems[0].Text;
      bool found = false;
      for (int i = 0; i < tsb.DropDownItems.Count; i++) {
        if (found) text = tsb.DropDownItems[i].Text;
        found = (tsb.Text == tsb.DropDownItems[i].Text);
      }
      tsb.Text = text;
    }
