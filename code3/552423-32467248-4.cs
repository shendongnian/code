    [TestMethod]
    public void TestId() {
       var emp = new Employee { Id = 3 };
       Assert.AreEqual(3, emp.Id);
    }
    [TestMethod]
    public void TestFirstName() {
       var emp = new Employee { FirstName = "asdf" };
       Assert.AreEqual("asdf", emp.FirstName);
    }
    [TestMethod]
    public void TestLastName() {
       var emp = new Employee { LastName = "asdf" };
       Assert.AreEqual("asdf", emp.LastName);
    }
    [TestMethod]
    public void TestAddress() {
       var address = new Address();
       var emp = new Employee { Address = address };
       Assert.AreEqual(address, emp.Address);
    }
