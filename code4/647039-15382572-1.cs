    for (int i = 0; i < dataGridView6.Rows.Count; i++)
    {   
        Row = DT.NewRow();
        string abbrCell1 = dataGridView6.Rows[i].Cells[0].Value.ToString();
        string abbrCell2 = dataGridView6.Rows[i].Cells[1].Value.ToString();
        Row[0] = dict[abbrCell1];
        Row[1] = dict[abbrCell2];
        DT.Rows.Add(Row);
    }
