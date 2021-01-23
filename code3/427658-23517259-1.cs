    foreach (ToolStripItem item in toolStripSearch.Items)
    {
          if (item.GetType() == typeof(ToolStripComboBox))
          {
              Pen cbBorderPen = new Pen(Color.Gray);
              Rectangle rect = new Rectangle(
                      ((ToolStripComboBox)item).ComboBox.Location.X - 1,
                      ((ToolStripComboBox)item).ComboBox.Location.Y - 1,
                      ((ToolStripComboBox)item).ComboBox.Size.Width + 1,
                      ((ToolStripComboBox)item).ComboBox.Size.Height + 1);
              e.Graphics.DrawRectangle(cbBorderPen, rect);
           }
}
