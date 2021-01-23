    using Moq.Protected;
    ...
    //Only works if DoSomethingCool is NOT virtual
    public void NotRecommended_ProbablyTestingTooMuch_BrittleTestBelow
    {
        var baseMock = new Mock<Base>();
        baseMock.Protected().Setup("OnDoingSomethingCool");
           
        baseMock.Object.DoSomethingCool();
        baseMock.Protected().Verify("OnDoingSomethingCool", Times.AtLeastOnce());
    }
