	public CustomPanel()
	{
		Initialized += OnInitialized;
	}
	private void OnInitialized(object sender, EventArgs eventArgs)
	{
		var b = new Button { Name = "Button1", Content = "Button1" };
		Children.Insert(0,b);
	}
