    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e) {
      e.DrawBackground();
      if ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected) {
        Rectangle r = new Rectangle(e.Bounds.Left + 4, e.Bounds.Top, TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Width, e.Bounds.Height);
        e.Graphics.FillRectangle(SystemBrushes.Highlight, r);
        e.Item.ForeColor = SystemColors.HighlightText;
      } else {
        e.Item.ForeColor = SystemColors.WindowText;
      }
      e.DrawText();
      e.DrawFocusRectangle();
    }
