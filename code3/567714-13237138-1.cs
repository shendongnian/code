    foreach (DataRow row in dt.Rows)
    {
        // Get values.
        string lname = row[0].Field<string>().Trim();
        string fname = row[1].Field<string>().Trim();
        string sString = row[2].Field<string>().Trim();
        string b = row[3].Field<string>().Trim();
        // Format/parse.
        lname = lname == "" ? null : lname;
        fname = fname == "" ? null : fname;
        long? s = sString == "" ? (long?) null : Convert.ToInt64(sString);
        string b = b == "" ? null : b;
        // Process the values.
    }
