    private void dataGridViewLifeSchedule_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
    	// 1. This is used to replace what is StringFormat.GenericDefault in the msdn code with strFormat
    	StringFormat strFormat = new StringFormat();
    	strFormat.Trimming = StringTrimming.None; 
    
    	Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
    	e.CellBounds.Y + 1, e.CellBounds.Width - 4,
    	e.CellBounds.Height - 4);
    
    	using (
    		Brush gridBrush = new SolidBrush(this.dataGridViewLifeSchedule.GridColor),
    		backColorBrush = new SolidBrush(e.CellStyle.BackColor)) {
    		using (Pen gridLinePen = new Pen(gridBrush)) {
    			// Erase the cell.
    			e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
    
    			// Draw the grid lines (only the right and bottom lines; 
    			// DataGridView takes care of the others).
    			e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
    				e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
    				e.CellBounds.Bottom - 1);
    			e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
    				e.CellBounds.Top, e.CellBounds.Right - 1,
    				e.CellBounds.Bottom);
    
    			// Draw the inset highlight box.
    			e.Graphics.DrawRectangle(Pens.BlanchedAlmond, newRect); // 2. It is Pens.Blue in the msdn code
    
    			// Draw the text content of the cell, ignoring alignment. 
    			if (e.Value != null) {
    				e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
    					Brushes.Black, e.CellBounds.X + 2, // 3. It is Brushes.Crimson in the msdn code
    					e.CellBounds.Y + 2, strFormat);
    			}
    			e.Handled = true;
    		}
    	}
    }
