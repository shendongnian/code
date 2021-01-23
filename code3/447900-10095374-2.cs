    private void listBox1_DrawItem(object sender, DrawItemEventArgs e) {
      e.DrawBackground();
      if (e.Index > -1) {
        Color textColor = SystemColors.WindowText;
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
          textColor = SystemColors.HighlightText;
        }
        TextRenderer.DrawText(e.Graphics, listBox1.Items[e.Index].ToString(), 
                              listBox1.Font, e.Bounds, 
                              textColor, Color.Empty, TextFormatFlags.NoPrefix);
      }
    }
