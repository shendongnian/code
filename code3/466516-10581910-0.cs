    var stateMachineMock = new Mock<IIceHockeyOddsStateMachine>();
    stateMachineMock.SetupAllProperties();
    stateMachineMock.Object.TeamAScore = 0;
    new IceHockeyActionLogRecord { Event = "goal", Team = "A"}.Replay(stateMachineMock.Object);
    Assert.That(stateMachineMock.Object.TeamAScore, Is.EqualTo(1));
