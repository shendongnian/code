    for (int i = 0; i < 15; i++)
    {
    DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
    c.Name = "Col" + i.ToString();
    gridView.Columns.Add(c);
    }
    gridView.Rows.Add(100);
    for (int i = 0; i < 100; i++)
    for (int j = 0; j < 15; j++)
    gridView.Rows[i].Cells[j].Value = "Val" + i.ToString() + "-" + j.ToString();
    gridView.Rows[0].Frozen = true;
    
