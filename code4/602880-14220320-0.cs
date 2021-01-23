    [TestMethod]
    public void TestDoStuff()
    {
        //+ Arrange
        myViewModel.IsSearchShowing = true;
        // container is my Unity container and it setup in the init method.
        container.Resolve<IOrderService>().Returns(orderService);
        orderService = Substitute.For<IOrderService>();
        var lookupTask = Task<IOrder>.Factory.StartNew(() =>
                                      {
                                          return new Order();
                                      });
        orderService.LookUpIdAsync(Arg.Any<long>()).Returns(lookupTask);
        
        //+ Act
        myViewModel.DoLookupCommand.Execute(0);
        lookupTask.Wait();
        //+ Assert
        myViewModel.IsSearchShowing.Should().BeFalse();
    }
