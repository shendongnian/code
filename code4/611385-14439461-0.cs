    var mock = new Mock<IFacebookChatClient>();
	// Tell mock to treat OnLogin as regular property
	// Second parameter is initial value (doesn't matter in your case)
	mock.SetupProperty(m => m.OnLogin, () => { });
	
	// perform test
	
	mock.Verify(m => m.SendMessage("Testing", "Hello World!"));
	
