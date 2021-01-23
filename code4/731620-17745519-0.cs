    if (precti3.HasRows)
    {
        precti3.Read();
        if (precti3.Item("subkey") != Null)
        {
            row.Cells[5].Value = true;
        }
        else
        {
            row.Cells[5].Value = false;
        }
    }
