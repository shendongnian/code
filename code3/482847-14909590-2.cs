    "Given a Options presenter"
        .Context(() =>
            presenter = new OptionsPresenter(view,
                                             A<IOptionsModel>.Ignored,
                                             service));
    
    "with the Save method called to save the option values"
        .Do(() => 
            exception = Record.Exception(() => presenter.Save()));
    
    "expect an ValidationException to be thrown"
        .Observation(() =>
            Assert.IsType<ValidationException>(exception)
         );
    
    "expect an service.SaveOptions method not to be called"
        .Observation(() =>
            A.CallTo(() => service.SaveOptions(A<IOptionsModel>.Ignored)).MustNotHaveHappened()
         );
