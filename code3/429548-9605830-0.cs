    void Control_KeyPress(object sender, KeyPressEventArgs e)
    {
        TimeSpan ts = new TimeSpan(0,0,10);  
        if (GridView1.CurrentCell.ColumnIndex < 0 || dataGridView1.CurrentCell.RowIndex< 0)  
            return;  
        if (orderObjectMapping[dataGridView1["OrderID", e.RowIndex].Value.ToString()].getElapsedStatusTime().CompareTo(ts) > 0)  
        {  
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();  
            cellStyle.ForeColor = Color.Red;  
            dataGridView1.Rows[GridView1.CurrentCell.RowIndex].Cells[GridView1.CurrentCell.ColumnIndex].Style = cellStyle;  
        } 
    }
