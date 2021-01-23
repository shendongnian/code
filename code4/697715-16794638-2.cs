    try
    {
    	NDde.Client.DdeClient client = new NDde.Client.DdeClient("TR1EMCodeEmulator", "Command");
    	client.Connect();
    	client.Advise += client_Advise;
    	DataRow[] rowList = dataTable1.Select("ALIASNUM > 0 ");
    	foreach (DataRow dr in rowList)
              client.StartAdvise(dr["ALIASNUM"] as String, 0, true, 60000);  //the zero is DDE type, replace as necessary
    }
    catch (Exception ex)
    {
    	//Do what you need to here...
    }
