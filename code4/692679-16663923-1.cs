    List<string> values = new List<string>();
    while (DR.READ())
    {
        values.Add(dr["COLUMN2"].ToString());
    }
    Label1.Text = String.Join(", ", values);
