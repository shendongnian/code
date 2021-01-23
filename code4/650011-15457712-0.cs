    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        var tempRow = dataTable[i];
        var temp = dataTable.Rows[0];
        for (int j = 0; j < dataTable.Rows.Count; j++)
        {
            DataRow rows = dataTable.Rows[j];
            if (temp == rows[0].ToString())
            {
                tempdatatable.Rows.Add(tempRow[0], tempRow[1]);
                dataTable.Rows.Remove(rows);      //Update happen here
            }
            tempdatatable.DefaultView.Sort = "gscitations DESC";
            dataGridView1.DataSource = tempdatatable;
        }
    }
