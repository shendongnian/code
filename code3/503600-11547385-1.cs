    public static DataView GetDataGridList(List<message> lstMessages) {
        DataTable dt = new DataTable();
        // Add the columns here for whatever properties you want
        dt.Columns.Add("subject");
        dt.Columns.Add("message");
        foreach (message msg in lstMessages) {
            DataRow dr = dt.NewRow(); // I think that's the call, I'm doing this off the top of my head, sorry.
            dr["subject"] = msg.subject;
            dr["message"] = msg.message;
        }
        return (dt.DefaultView);
    }
