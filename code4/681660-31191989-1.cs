    var sessionImplMock = new Mock<NHibernate.Engine.ISessionImplementor>(MockBehavior.Strict);
    var factoryMock = new Mock<NHibernate.Engine.ISessionFactoryImplementor>(MockBehavior.Strict);
    var queryMock = new Mock<IQuery>(MockBehavior.Strict);//ExpressionQueryImpl
    sessionImplMock.Setup(x => x.Factory).Returns(factoryMock.Object);
    sessionImplMock.Setup(x => x.CreateQuery(It.IsAny<IQueryExpression>())).Returns(queryMock.Object);
    sessionMock.Setup(x => x.GetSessionImplementation()).Returns(sessionImplMock.Object);
