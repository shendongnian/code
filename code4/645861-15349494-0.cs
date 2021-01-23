        var mockControllerContext = new Mock<ControllerContext>();
        var mockSession = new Mock<HttpSessionStateBase>();
        mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
        var controller = new MyController();
        controller.ControllerContext = mockControllerContext.Object;
