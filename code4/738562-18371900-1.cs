    var dispatcher = A.Fake<IDispatcher>();
    dispatcher.Dispatch(new NewCommand(), new Stuff());
    A.CallTo(() => dispatcher.Dispatch(A<Command>.Ignored,
                                        A<Stuff>.Ignored,
                                        A<TimeSpan?>.Ignored,
                                        A<int?>.Ignored)).MustNotHaveHappened();
