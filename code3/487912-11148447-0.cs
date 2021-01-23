	public class TaskGroupCreator
	{
		private string[] values;
			
		public TaskGroupCreator(string[] values)
		{
			this.values = values;
		}
	
		public string TaskGroupName
		{
			get { return values[0]; }
		}
	
		public string Market
		{
			get { return values.ElementAtOrDefault(1) ?? "en-us"; }
		}
		
		public string Project 
		{
			get { return values.ElementAtOrDefault(2) ?? "MyProject"; }
		}
		
		public string Team 
		{
			get { return values.ElementAtOrDefault(3) ?? "DefaultTeam"; }
		}
		
		public string SatelliteID 
		{
			get { return values.ElementAtOrDefault(4) ?? "abc"; }
		}
		
		public int CreateTaskGroup()
		{
			// Do stuff with your properties...
		}
	}
