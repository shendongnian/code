	private static void Main()
	{
		ServiceBase.Run(new ServiceBase[]
                	{
                		new CometService()
                	});
	}
