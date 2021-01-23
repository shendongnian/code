    DataTable dtAll = ds.Tables[0].Copy();
    for (var i = 1; i < ds.Tables.Count; i++)
    {
         dtAll.Merge(ds.Tables[i]);
    }
    DataGridView1.AutoGenerateColumns = true;
    DataGridView1.DataSource = dtAll ;
