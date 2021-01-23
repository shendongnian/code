    "Given an options presenter"
        .Given(() => presenter =
            new OptionsPresenter(view, A<IOptionsModel>.Ignored, service));
    
    "When saving the options presenter"
        .When(() => exception = Record.Exception(() => presenter.Save()));
    
    "Then a validation exception is thrown"
        .Then(() => exception.Should().BeOfType<ValiationException>());
    
    "And the options model must not be saved"
        .And(() => A.CallTo(() =>
            service.SaveOptions(A<IOptionsModel>.Ignored)).MustNotHaveHappened());
