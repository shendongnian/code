    // 1
	public void DoSomething_AddsItemOnMyInterface()
	{
	    var myInterface = MocksRepository.GenerateMock<IMyInterface>();
		myInterface.Expect(m => m.AddItem()).Repeat.Once();
		
		cut.DoSomething(myInterface);
		
		myInterface.VerifyAllExpectations();
	}
	
	// 2
	public void ItemAdded_?ExpectedResult?_WhenMyInterfaceRaisesEvent()
	{
	    var myInterface = MocksRepository.GenerateMock<IMyInterface>();
		myInterface.Expect(m => m.AddItem()).Repeat.Once();
		myInterface.Raise(m => m.ItemAddedEvent += null, myInterface,
		    new ItemAddedEventArgs());
	
		// ExpectedResult goes here, that is what you assert here depends on what
		// exactly ItemAdded method does; usually it's easiest to verify object
		// state - but it's hard to tell since you didn't show any code.
	}
	
