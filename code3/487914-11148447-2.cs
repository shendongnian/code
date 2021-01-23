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
			get { return this.GetElement(1, "en-us"); }
		}
		
		public string Project 
		{
			get { return this.GetElement(2, "MyProject"); }
		}
		
		public string Team 
		{
			get { return this.GetElement(3, "DefaultTeam"); }
		}
		
		public string SatelliteID 
		{
			get { return this.GetElement(4, "abc"); }
		}
		
		public int CreateTaskGroup()
		{
			// Do stuff with your properties...
		}
		
		private string GetElement(int index, string defaultValue)
		{
			return this.values.ElementAtOrDefault(index) ?? defaultValue;
		}
	}
