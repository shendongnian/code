    var commSettings = MockRepository.GenerateStub<ICommunicationSettings>();
    var logic = new MyLogicForSomething(commSettings );
    
    logic.PerformSomething()
    commSettings.AssertWasCalled( x => x.SaveSetting(null), o=>o.IgnoreArguments() );
