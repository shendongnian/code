    "Given an options presenter"
        .x(() => presenter = new OptionsPresenter(view, A<IOptionsModel>.Ignored, service));
    
    "When saving the options presenter"
        .x(() => exception = Record.Exception(() => presenter.Save()));
    
    "Then a validation exception is thrown"
        .x(() => exception.Should().BeOfType<ValiationException>());
    
    "And the options model must not be saved"
        .x(() => A.CallTo(() =>
            service.SaveOptions(A<IOptionsModel>.Ignored)).MustNotHaveHappened());
