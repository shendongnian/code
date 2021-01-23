    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
      if (e.ColumnIndex > 0) {
        e.DrawBackground();
        string searchTerm = "Term";
        int index = e.SubItem.Text.IndexOf(searchTerm);
        if (index >= 0) {
          string sBefore = e.SubItem.Text.Substring(0, index);
          Size bounds = new Size(e.Bounds.Width, e.Bounds.Height);
          Size s1 = TextRenderer.MeasureText(e.Graphics, sBefore, this.Font, bounds);
          Size s2 = TextRenderer.MeasureText(e.Graphics, searchTerm, this.Font, bounds);
          Rectangle rect = new Rectangle(e.Bounds.X + s1.Width, e.Bounds.Y, s2.Width, e.Bounds.Height);
          e.Graphics.SetClip(e.Bounds);
          e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), rect);
          e.Graphics.ResetClip();
        }
        e.DrawText();
      }
    }
