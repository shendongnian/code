    foreach (ToolStripItem cb in toolStripSearch.Items)
    {
          if (cb.GetType() == typeof(ToolStripComboBox))
          {
              Pen cbBorderPen = new Pen(Color.Gray);
              Rectangle r = new Rectangle(
                      ((ToolStripComboBox)item).ComboBox.Location.X - 1,
                      ((ToolStripComboBox)item).ComboBox.Location.Y - 1,
                      ((ToolStripComboBox)item).ComboBox.Size.Width + 1,
                      ((ToolStripComboBox)item).ComboBox.Size.Height + 1);
              e.Graphics.DrawRectangle(cbBorderPen, r);
           }
}
