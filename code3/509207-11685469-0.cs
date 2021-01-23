    DataRow row = dataTable.NewRow();
    row["columnName"] = valueYouWantToUse;
    //any other information can be put here too, for each column in the row.
    dataTable.Rows.Add(row);
     if (parts[i] != "")
                    {
                        dataGridView1.Rows.Add((new Object[] { i, parts[i]}));
                        dataGridView1.Columns.Add("Link", "Name");
                        DataRow row = dataTable.NewRow();
                        row["Link"] = i.ToString();
                        row["Name"] = parts[i].ToString();
                        
                        //here add all your column values for that row in the same manner, then,
                        dataTable.Rows.Add(row);
                    }
