    public class Dependency {
        public string Foo() {
           return "foo";  // machine, system, time, something else, dependent result
        }
        public string Bar() {
           return "bar";
        }
    }
    public class MySimpleClass {
			
        public string MyFunc() {
             return new Dependency().Foo();
        }
    
    }
    [TestMethod]
    public void TestSimple() {
        var client = new MySimpleClass();
        Assert.AreEqual("foo", client.MyFunc());
    }
