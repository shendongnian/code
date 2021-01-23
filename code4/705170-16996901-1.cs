    void dgRulesMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex > -1 & e.ColumnIndex == 3)
      {
        var editingCellFormattedValue = Convert.ToBoolean(((DataGridViewCheckBoxCell)dgRulesMaster.Rows[dgRulesMaster.CurrentRow.Index].Cells[3]).EditingCellFormattedValue);
        if (editingCellFormattedValue == false)
        {
          dgRulesMaster[2, e.RowIndex].ReadOnly = true;
          dgRulesMaster.InvalidateCell(2,e.RowIndex);
        }
      }   
     } 
     //And here is the CellPainting event handler for your dataGridView
     private void dgRulesMaster_CellPainting(object sender, DataGridViewCellPaintingEventArgs e){
        if (e.ColumnIndex > -1 && e.RowIndex > -1 && 
           dgRulesMaster.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && dgRulesMaster[e.ColumnIndex, e.RowIndex].ReadOnly)
            {
                Size checkSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);                
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                if (e.Value != null)
                {
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.CellBounds.X + e.CellBounds.Width / 2 - checkSize.Width / 2, e.CellBounds.Y + e.CellBounds.Height / 2 - checkSize.Height / 2), 
                   (bool)e.Value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedDisabled);                    
                }
            }
      }    
