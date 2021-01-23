    if(reader.HasRows)
    {
        do
        {
            DatabaseObject obj = new DatabaseObject();
            for (int i = 0; i < row_count; i++)
            {
                obj.Items.Add(reader.GetString(i));
            }
            tabView.Items.Add(obj);
        }
        while(reader.NextResult());
    }
