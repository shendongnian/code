	public class CustomDataHandler : ICustomData
	{
		private string CustomData { set; get; }
    
		string ICustomData.CustomData { get; set; }
	}
