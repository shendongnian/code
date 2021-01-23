    // Allow Combo Box to center aligned
    private void cbxDesign_DrawItem(object sender, DrawItemEventArgs e)
    {
      // By using Sender, one method could handle multiple ComboBoxes
      ComboBox cbx = sender as ComboBox;
      if (cbx != null)
      {
        // Always draw the background
        e.DrawBackground();
     
        // Drawing one of the items?
        if (e.Index >= 0)
        {
          // Set the string alignment.  Choices are Center, Near and Far
          StringFormat sf = new StringFormat();
          sf.LineAlignment = StringAlignment.Center;
          sf.Alignment = StringAlignment.Center;
     
          // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
          // Assumes Brush is solid
          Brush brush = new SolidBrush(cbx.ForeColor);
     
          // If drawing highlighted selection, change brush
          if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            brush = SystemBrushes.HighlightText;
     
          // Draw the string
          e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
        }
      }
    }
