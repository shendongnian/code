    private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
            if (e.Value == null) return;
            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            e.PaintContent(e.CellBounds);
            if (e.ColumnIndex > -1&&e.RowIndex > -1&&dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {                
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                object dataBoundItem = dataGridView.Rows[e.RowIndex].DataBoundItem;
                if(dataBoundItem != null && dataBoundItem.GetType() == typeof(EditGrid)){
                  e.Graphics.DrawString(((EditGrid)dataBoundItem).edit.Text, dataGridView.Font, Brushes.Black, e.CellBounds, sf);
                }
            }
    }
