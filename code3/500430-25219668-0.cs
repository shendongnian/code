     private void grdRegClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdRegClass.Columns.IndexOf(grdRegClass.Columns["Status"]) == e.ColumnIndex)
            {
                int currentcolumnclicked = e.ColumnIndex;
                int currentrowclicked = e.RowIndex;
                foreach (DataGridViewRow dr in grdRegClass.Rows)
                {
                    dr.Cells[currentcolumnclicked].Value = false;
                }
                grdRegClass.CurrentRow.Cells[currentrowclicked].Value = true;  
            }
        }
