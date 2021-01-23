    [TestClass]
    public sealed TestEmployee {
       [TestMethod]
       public void TestSimpleProperties() {
          Assert.IsTrue(
             SimplePropertyTester.Create(
                new SimplePropertyTestCollection<Employee> {
                   { emp => emp.Id, 3 },
                   { emp => emp.FirstName, "asdf" },
                   { emp => emp.LastName, "1234" },
                   { emp => emp.Address, new Address() }
                }
             ).Test()
          );
       }
    }
