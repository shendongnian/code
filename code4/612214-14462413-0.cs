	using System.Management.Automation.Runspaces;
	//...
	var rsConfig = RunspaceConfiguration.Create();
	using (var myRunSpace = RunspaceFactory.CreateRunspace(rsConfig))
	{
		PSSnapInException snapInException = null;
		var info = rsConfig.AddPSSnapIn("FULL.SNAPIN.NAME.HERE", out snapInException);
		
		myRunSpace.Open();
		using (var pipeLine = myRunSpace.CreatePipeline())
		{
			Command cmd = new Command("YOURCOMMAND");
			cmd.Parameters.Add("PARAM1", param1);
			cmd.Parameters.Add("PARAM2", param2);
			cmd.Parameters.Add("PARAM3", param3);
			pipeLine.Commands.Add(cmd);
			pipeLine.Invoke();
			if (pipeLine.Error != null && pipeLine.Error.Count > 0)
			{
				//check error
			}
		}
	}
