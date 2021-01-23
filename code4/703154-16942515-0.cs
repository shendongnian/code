    List<object> list = new List<object>();
    foreach (object row in DataGridView.Rows)
        {
        List<object> newList = new List<object>();
        list.Add(newList);
        foreach (object columns in row)
        {
            newList.Add(columns.DataBoundItem);
        }
        }
