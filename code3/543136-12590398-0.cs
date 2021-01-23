    foreach (DataTable dt in ds.Tables) {
        foreach (DataRow row in dt.Rows) {
            var uc = new YourUserControl { Username = row["usernameColumn"].ToString(), 
                                           Name = row["nameColumn"].ToString() };
            flowLayoutPanel1.Controls.Add(uc);
        }
    }
