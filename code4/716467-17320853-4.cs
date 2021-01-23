    [TestMethod()]
    public void SaveEmployeeDataTest()
    {
        var a = new Mock<IRepository>();
        var sameEmployee = new Employee();
        a.Setup(s => s.Save(sameEmployee)).Returns(true).Verifiable();
        var service = new EmployeeService(a.Object);
        var result = service.SaveEmployeeData(sameEmployee, true);
        Assert.IsTrue(result);
    }
