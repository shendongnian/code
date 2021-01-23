    [TestMethod]
    public async Task TestDoStuff()
    {
      //+ Arrange
      myViewModel.IsSearchShowing = true;
      // container is my Unity container and it setup in the init method.
      container.Resolve<IOrderService>().Returns(orderService);
      orderService = Substitute.For<IOrderService>();
      orderService.LookUpIdAsync(Arg.Any<long>())
                  .Returns(new Task<IOrder>(() => null));
      //+ Act
      await myViewModel.DoLookupCommandImpl(0);
      //+ Assert
      myViewModel.IsSearchShowing.Should().BeFalse();
    }
