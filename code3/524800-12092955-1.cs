	public static void GeneralHandler(object sender, EventArgs args)
	{
		instance.Handle(sender, args);
	}
	private static MyProcessingClass instance = new MyProcessingClass();
