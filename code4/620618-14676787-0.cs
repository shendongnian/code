    using (mocks.Record())
    {
        myMock.AVeryMeaningFullMethodThatDoesNotReturnAValue("a to be ignored parameter");
        LastCall.IgnoreArguments();
    
        Expect.Call(myMock.AnotherMethodThatDoesReturnAValue()).IgnoreArguments().Returns("barney");
    }
