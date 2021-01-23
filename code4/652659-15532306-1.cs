    using Moq.Protected;
    ...
    public void NotRecommended_ProbablyTestingTooMuch_BrittleTestBelow
    {
        //If you MUST keep DoSomethingCool virtual
        //var baseMock = new Mock<Base>{CallBase = true};
        var baseMock = new Mock<Base>();
        baseMock.Protected().Setup("OnDoingSomethingCool");
           
        baseMock.Object.DoSomethingCool();
        baseMock.Protected().Verify("OnDoingSomethingCool", Times.AtLeastOnce());
    }
