    for (int i = 0; i < dt.Columns.Count; i++)
	{
        DataColumn dc = dt.Columns[i];
	    BoundField bf = new BoundField();
        bf.ReadOnly = i == 0;  // will take care of setting controls to readonly in column 0
        bf.DataField = dc.ColumnName;
        GridView1.Columns.Add(bf);
    }
