    RadarServerEntities rse = new RadarServerEntities();
    gvUsers.DataSource = rse.Users;
    gvUsers.AutoGenerateColumns = false;
    gvUsers.Columns.Remove("ID");
    gvUsers.Columns.Remove("InsertDate");
    gvUsers.Columns.Remove("Connections");
    gvUsers.Columns.Remove("MachineID");
