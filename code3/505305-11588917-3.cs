    private void button1_Click(object sender, EventArgs e)
    {
        dgv.AutoGenerateColumns = false;
        DataTable dt = new DataTable();
        dt.Columns.Add("Text");
        dt.Columns.Add("CheckBox");
        for (int i = 0; i < 3; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i.ToString();
            dt.Rows.Add(dr);
        }
        dgv.DataSource = dt;            
    }
        
    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        foreach (DataGridViewRow row in dgv.Rows)
        {
            var oCell = row.Cells[1] as DataGridViewCheckBoxCell;
            bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
        }
    }
