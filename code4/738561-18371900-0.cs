    dispatcher.Dispatch(new Command(), new Stuff());
    A.CallTo(() => dispatcher.Dispatch(A<Command>.Ignored,
                                        A<Stuff>.Ignored,
                                        A<TimeSpan?>.Ignored,
                                        A<int?>.Ignored)).MustNotHaveHappened();
