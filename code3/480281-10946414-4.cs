    // 1: This test will simply verify that tested method calls dependency
	public void DoSomething_AddsItemOnMyInterface()
	{
	    var myInterface = MocksRepository.GenerateMock<IMyInterface>();
		myInterface.Expect(m => m.AddItem()).Repeat.Once();
		
		cut.DoSomething(myInterface);
		
		myInterface.VerifyAllExpectations();
	}
	
	// 2: Here we assure that model gets updated when item was added
	public void ItemAdded_UpdatesModel_WhenMyInterfaceRaisesEvent()
	{
	    var myInterface = MocksRepository.GenerateMock<IMyInterface>();
		myInterface.Expect(m => m.AddItem()).Repeat.Once();
		myInterface.Raise(m => m.ItemAddedEvent += null, myInterface,
		    new ItemEventArgs());
			
		// How exactly model is updated when event is raised? The 'how'
		// should be asserted here.
	}
	
