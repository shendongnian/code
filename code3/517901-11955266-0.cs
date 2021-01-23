    private void HPQC_Create_Test_Plan_Test(TDConnectionClass tdConnection, string ParentFolderPath, string TestName)
		{
			try
			{
				TreeManager treeM = (TreeManager)tdConnection.TreeManager;
				ISysTreeNode ParentFolder = (ISysTreeNode)treeM.get_NodeByPath(ParentFolderPath);
				TestFactory TestF = (TestFactory)tdConnection.TestFactory;
																
				Test TstTest = (Test)TestF.AddItem(System.DBNull.Value);
				TstTest.Name = TestName;
				TstTest.Type = "MANUAL";
				TstTest["TS_SUBJECT"] = ParentFolder.NodeID;
				TstTest.Post();
										
				HPQC_Status_Test_Plan.Text = "Test " + TestName + " created.";
				tdConnection.Logout();
				tdConnection.Disconnect();
				tdConnection = null;
			}
			catch (Exception ex)
			{
				HPQC_Status_Test_Plan.Text = "Test Creation Failed.";
				Console.WriteLine("[Error] " + ex);
				tdConnection.Logout();
				tdConnection.Disconnect();
				tdConnection = null;
			}
		}
