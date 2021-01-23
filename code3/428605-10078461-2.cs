    DataTable dt = new DataTable();
    for (int i = 0; i < dgvPaperAndPlastic.Columns.Count; i++)
    {
         DataColumn column = new DataColumn(dgvPaperAndPlastic.Columns[i].HeaderText);
         dt.Columns.Add(column);
    }
    int noOfColumns = dgvPaperAndPlastic.Columns.Count;
    foreach (DataGridViewRow dr in dgvPaperAndPlastic.Rows)
    {
         //Create table and insert into cell value.
         DataRow dataRow = dt.NewRow();
         for (int i = 0; i < noOfColumns; i++)
         {
              dataRow[i] = dr.Cells[i].Value.ToString();
         }
    }
