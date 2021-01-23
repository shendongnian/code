    foreach (var item in toolStrip1.Items)
    {
          var asComboBox = item as ToolStripComboBox;
          if (asComboBox != null)
          {
              var location = asComboBox.ComboBox.Location;
              var size = asComboBox.ComboBox.Size;
              Pen cbBorderPen = new Pen(Color.Gray);
              Rectangle rect = new Rectangle(
                      location.X - 1,
                      location.Y - 1,
                      size.Width + 1,
                      size.Height + 1);
              e.Graphics.DrawRectangle(cbBorderPen, rect);
           }
}
