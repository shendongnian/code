    public DataSet GetGmailContacts(string p_name, string e_id, string psw)
    {
        //p_name = name of your app; e_id = your gmail account; psw = password of your gmail account
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dc1 = new DataColumn();
        dc1.DataType = Type.GetType("System.String");
        dc1.ColumnName = "emailid";
        DataColumn dc2 = new DataColumn();
        dc2.DataType = Type.GetType("System.String");
        dc2.ColumnName = "name";
        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);
        RequestSettings rs = new RequestSettings(p_name, e_id, psw);
        rs.AutoPaging = true;
        ContactsRequest cr = new ContactsRequest(rs);
        Feed<Contact> f = cr.GetContacts();
        int counter= 0;
        foreach (Contact t in f.Entries)
        {
            Name nombreContacto = t.Name;
            DataRow drx = dt.NewRow();
            drx["emailid"] = t.PrimaryEmail.Address.ToString();
            drx["name"] = t.Title.ToString();
            dt.Rows.Add(drx);
            counter++;
        }
        ds.Tables.Add(dt);
        Response.Write("Total:" + counter.ToString());
        return ds;
    }
