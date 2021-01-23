    public class Daddy {
        public List<MyClass> DoSomething(string Name, string Address,                  string Email, out string ErrorMessage, IDataProvider provider)
        {
          //Check for empty string parameters etc now go and get some data   
          List<MyClass> Data = provider.GetData(Name, Address, Email);
          List<MyClass> formattedData = FormatData(Data);
          return formattedData;
        }
    }
    [TestClass]
    public class DaddyTest {
        [TestMethod]
        public void DoSomethingHandlesEmptyDataSet() {
            // set-up
            Daddy daddy = new Daddy();
            // test
            IList<MyClass> result = daddy.DoSomething("blah",
                                                      "101 Dalmation Road",
                                                      "bob@example.com",
                                                      out error,
                                                      new FakeProvider(new Enumerable.Empty<AcmeData>())); // a class we've written to act in lieu of the real provider
            // validate
            Assert.NotNull(result); // most testing frameworks provides Assert functionality
            Assert.IsTrue(result.Count == 0);
            Assert.IsFalse(String.IsNullOrEmpty(error));
        }
    }
}
