    StringBuilder sb = new StringBuilder(1024); /* arbitrary size */
    while (reader.read())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            sb.Append(reader.GetName(i));
            sb.Append(": ");
            sb.Append(reader[i]);
        }
        sb.Append("<br />");
    }
    lblResult.Text = sb.ToString();
