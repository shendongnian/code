    [TestClass]
    public sealed TestEmployee {
       [TestMethod]
       public void TestSimpleProperties() {
          var factory = SimplePropertyTestFactory.Create<Employee>();
          new SimplePropertyTestCollection<Employee> {
             factory.IntTest(emp => emp.ID),
             factory.StringTest(emp => emp.FirstName),
             factory.StringTest(emp => emp.LastName),
             factory.ReferenceTest(emp => emp.Address)
          }.Test();
       }
    }
