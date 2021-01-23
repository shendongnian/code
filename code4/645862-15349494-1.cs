        var mockControllerContext = new Mock<ControllerContext>();
        var mockSession = new Mock<HttpSessionStateBase>();
        mockSession.SetupGet(s => s["altUser"]).Returns("user");
        mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
        var controller = new MyController();
        controller.ControllerContext = mockControllerContext.Object;
