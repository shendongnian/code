	public class WebRole : RoleEntryPoint
	{
		public override void Run()
		{
			RemoveIISTimeouts();
			base.Run();
		}
		private void RemoveIISTimeouts()
		{
			Process.Start(
				String.Format(@"{0}\system32\inetsrv\appcmd", Environment.GetEnvironmentVariable("windir")),
				"set config -section:applicationPools -applicationPoolDefaults.processModel.idleTimeout:00:00:00");
		}
	}
