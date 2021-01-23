    _Service.AssertWasNotCalled(s => s.Login(
	    Arg<string>.Is.Anything,
        Arg<string>.Is.Anything,
		Arg<int>.Is.Anything ,
        out Arg<int>.Out(10).Dummy
	));
