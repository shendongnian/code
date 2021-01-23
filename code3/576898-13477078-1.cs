    List<string> rowData = new List<string>();
    for (int i = 0; i < noOfColumns; i++)
    {
       rowData.Add(dgvr.Cells[i].Value.ToString());
    }
    dsptable.Rows.Add(rowData.ToArray());
