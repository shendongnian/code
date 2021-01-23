    bool isFirst = true;
    while (sdr.Read())
    {
        if (isFirst) isFirst = false;
        else writer.WriteLine(",");
        //Pull each line from DB
        the_title = sdr["the_title"].ToString();
        the_cats = sdr["the_category"].ToString();
        the_tags = sdr["the_tags"].ToString();
        the_date = sdr["the_date"].ToString();
        //Start file creation
        writer.WriteLine("[");
        writer.WriteLine("\"" + the_title + "\", ");
        writer.WriteLine("\"" + the_cats + "\", ");
        writer.WriteLine("\"" + the_tags + "\", ");
        writer.WriteLine("\"" + the_date + "\", ");
        writer.WriteLine("\"<a href=\\\"#\\\" class=\\\"sepV_a\\\" title=\\\"Edit\\\"><i class=\\\"icon-pencil\\\"></i></a>\"");
        writer.Write("]");
    }
    writer.WriteLine();
