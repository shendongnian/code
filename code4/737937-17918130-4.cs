    [Test]
    public void ShoulReturnAllOrders()
    {
        List<Order> orders = CreateListOfOrders();
        var mock = new Mock<IOrderRepository>();
        mock.Setup(r => r.FindAll()).Returns(orders);
        var controller = new SalesController(mock.Object);
        var result = (ViewResult)controller.Index();
        mock.VerifyAll();
        Assert.That(result.Model, Is.EqualTo(orders));
    }
