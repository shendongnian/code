    objc.ClientName = Convert.ToString(Session["ClientName"]);
    DataSet ClientN = obj.GetClientList();
    DataView Projview = new DataView();
    Projview.Table = ClientN.Tables[0];
    DrpClientName.DataSource = Projview;
    DrpClientName.DisplayMember = "Column name that you want to display";
    DrpClientName.ValueMember = "Column name that you want to get the values from";
