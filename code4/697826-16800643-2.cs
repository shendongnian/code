    var mockSF = new Mock<ISomeInterface>(MockBehavior.Strict);
    var cnt = 0;
    
    mockSF.Setup(m => m.SomeMethod(It.Is<int>(i => i != -1)));
    mockSF.Setup(m => m.SomeMethod(It.Is<int>(i => i == 12345))).Callback(() =>cnt++).AtMostOnce();
