    if (sqlreader.Read())
    {
        var columnOrdinal = sqlreader.GetOrdinal("Name");
        if (sqlReader.IsDBNull(columnOrdinal))
            NameLabel.Text = string.Empty;
        else
            Namelabel.Text = sqlreader.GetString(columnOrdinal);
    }
