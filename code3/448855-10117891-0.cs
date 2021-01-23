    if (e.ColumnIndex == 0 && e.RowIndex >= 0)//Assuming the checkbox is in Column 0
            {
                e.PaintBackground(e.ClipBounds, false);
                int index = 0;//Unchecked image
                if (e.Value != null && (bool)e.Value == true)
                    index = 1;//Checked image
                    e.Graphics.DrawImageUnscaled(imageList1.Images[index], e.CellBounds.X + 5, e.CellBounds.Y + 5);
    
                e.Handled = true;
            }
