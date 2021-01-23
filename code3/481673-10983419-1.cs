    DataTable dt = new DataTable();
    
    DataColumn dcRoom = new DataColumn("Room", typeof(DropDownList));
    DataColumn dcAdults = new DataColumn("Adults", typeof(string));
    DataColumn dcChildren = new DataColumn("Children", typeof(string));
    DataColumn dcCheckIn = new DataColumn("CheckIn", typeof(string));
    DataColumn dcCheckOut = new DataColumn("CheckOut", typeof(string));
    
    dt.Columns.AddRange(new DataColumn[] { dcRoom, dcAdults, dcChildren, dcCheckIn, dcCheckOut });
    
    dt.Rows.Add(new object[] { new DropDownList(), "", "", "", "" });
    gvRP.DataSource = dt;
    gvRP.DataBind();
