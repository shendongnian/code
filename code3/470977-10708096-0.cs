    public List<string> GetEmailList()
    {
        // get DataTable dt from somewhere.
        List<string> sEmail = new List<string>();
        foreach (DataRow row in dt.Rows)
        {
            sEmail.Add(row[0].ToString());
        }
        return sEmail; // Ultimately to get a string list.
    }
