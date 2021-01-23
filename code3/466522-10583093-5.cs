    [TestCase(0, 1)]
    [TestCase(50, 51)]
    public void ShouldIncrementTeamScore(int initialScore, int expectedScore)
    {
        var stateMachineMock = new Mock<IIceHockeyOddsStateMachine>();
        stateMachineMock.SetupGet(s => s.TeamAScore).Returns(initialScore);
        IceHockeyActionLogRecord foo = new IceHockeyActionLogRecord();
        foo.Replay(stateMachineMock.Object);
        stateMachineMock.VerifySet(s => s.TeamAScore = expectedScore);            
    }
