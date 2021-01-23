    foreach(DataRow row in ds.Tables["title"].Rows)
    {
        // ...
        Hyperlink hl = new HyperLink(); // you don't need the array of hyperlinks neither
        hl.ID = "hyperlink" + i;
        string title = row.Field<string>("title);
        hl.Text = title;
        coo["sogtit"] = title;
        Panel1.Controls.Add(hl);
        // ...
    }
