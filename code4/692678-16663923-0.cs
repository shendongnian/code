    StringBuilder sb = new StringBuilder();
    boolean doneFirstRow = false;
    while (DR.READ())
    {
        if (doneFirstRow) 
        {
            sb.Append(", ");
        }
        else 
        {
            doneFirstRow = true;
        }
        sb.Append(dr["COLUMN2"].ToString());
    }
    Label1.Text = sb.ToString();
