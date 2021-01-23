	void SetBackbufferPreserveContents(object sender,
	                                   PreparingDeviceSettingsEventArgs e)
	{
		e.GraphicsDeviceInformation.PresentationParameters.RenderTargetUsage
				= RenderTargetUsage.PreserveContents;
	}
	// in your game constructor:
	graphics.PreparingDeviceSettings += SetBackbufferPreserveContents;
