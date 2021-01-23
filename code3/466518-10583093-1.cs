    // Arrange
    Mock<IIceHockeyOddsStateMachine> stateMachineMock = new Mock<IIceHockeyOddsStateMachine>();
    stateMachineMock.Setup(s => s.TeamAScore).Returns(0);
    IceHockeyActionLogRecord record = new IceHockeyActionLogRecord { Event = "goal", Team = "A"};
    // Act
    record.Replay(stateMachineMock.Object);
    // Assert
    stateMachineMock.VerifySet(s => s.TeamAScore = 1); 
