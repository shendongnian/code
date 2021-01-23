    private void HPQC_Req_Create_Click()
		{
			TDConnection td = null;
			try
			{
				td = new TDConnection();
				td.InitConnectionEx("server");
				td.Login(HPQCUIDTextbox.Text.ToString(), HPQCPassTextbox.Text.ToString());
				Console.WriteLine(HPQCPassTextbox.Text.ToString());
				td.Connect("DEFAULT", "Test_Automation_Playground");
				bool check = td.LoggedIn;
				if (check == true)
				{
					Console.WriteLine("Connected.");
					HPQCStatus.Text = "Connected.";
				}
				ReqFactory myReqFactory = (ReqFactory)td.ReqFactory;
				Req myReq = (Req)myReqFactory.AddItem(-1); //Error Here
				myReq.Name = "New Requirement 1";
				myReq.TypeId = "1"; // 0=Business, 1=Folder, 2=Functional, 3=group, 4=testing 
				myReq.ParentId = 0;
				myReq.Post();
				 
				Console.WriteLine("Requirement Created.");
				HPQCStatus.Text = "Requirement Created.";
											
				try
				{
					td.Logout();
					td.Disconnect();
					td = null;
				}
				catch
				{ }
			}
			catch (Exception ex)
			{
				Console.WriteLine("[Error] " + ex);
				try
				{
					td.Logout();
					td.Disconnect();
					td = null;
				}
				catch
				{ }
			}
