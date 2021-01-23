    [TestMethod]
    public void VerifyRepositoryOutputIsReturned()
    {    
        var widget1 = new Widget();
        var widget2 = new Widget();
        var listOfWidgets = new List<Widget>() {widget1, widget2};
        var widgetRepository = new Mock<IWidgetRepository>();
        widgetRepository.Setup(r => r.Retrieve())
          .Returns(listOfWidgets.AsQueryable());
        var controller = new WidgetController();
        controller.WidgetRepository = widgetRepository.Object;
    
        var results = controller.Get();
        
        Assert.AreEqual(2, results.Count());
        Assert.IsTrue(results.Contains(widget1));
        Assert.IsTrue(results.Contains(widget2));
    }
