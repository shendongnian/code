    //you can test whether it makes any difference in performance declaring a single
    //StringBuilder and clearing, or creating a new one per loop
    var sb = new StringBuilder();
    while (rdr.Read())
    {
        for (int index = 0; index < rdr.FieldCount; index++)
            sb.Append(rdr[index].ToString().Replace(',', ' ').Append(',');
        write(sb.ToString(), filename); //uses StreamWriter.WriteLine()
        sb.Clear();
    }
