	public class OrderParsingRunner
	{
		private readonly OrderParser orderParser;
		
		public OrderParsingRunner(OrderParser orderParser)
		{
			this.orderParser = orderParser;
		}
		
		public StartWorking()
		{
			TaskFactory.StartNew(() => 
				{ 
					DoWorkHourly();
				});
		}
		private DoWorkHourly()
		{
			while(true)
			{
				Thread.Sleep(TimeSpan.FromHours(1));
				
				orderParser.DoWork();
			}
		}
	}
    
