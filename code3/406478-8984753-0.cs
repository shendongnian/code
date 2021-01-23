     private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
     {
       if (e.RowIndex==1 && e.ColumnIndex==1)
       {
        using (Image img = Image.FromFile(@"c:\file\file.gif"))
         {
           e.Graphics.DrawImage(img, e.CellBounds.Left, e.CellBounds.Top - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
    
           e.PaintContent(e.ClipBounds);
           e.Handled = true;
          }
        }
     }
