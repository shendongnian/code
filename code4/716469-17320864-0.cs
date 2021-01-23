    [TestMethod()]
    public void SaveEmployeeDataTest()
    {
        var a = new Mock<IRepository>();
    	var employee = new Employee();
        a.Setup(s => s.Save(employee)).Returns(true).Verifiable();
        var result = new EmployeeService(a.Object).SaveEmployeeData(employee, true);
        Assert.IsTrue(result);
    }
