    for(var i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    {
        DataRow item = ds.Tables[0].Rows[i];
        
        Appliction app = new Application();
        app.Name = item["Name"].ToString();
        app.Confidentiality = int.Parse(item["Conf"].ToString());
        app.Id = item["ID"].ToString();
        appList[i] = app
    }
