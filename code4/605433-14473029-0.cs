    [TestFixture]
    public class FooController Tests 
    {
        [Test]
        public void Verify_Index_Is_Decorated_With_My_Attribute() {
            var controller = new FooController ();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Index");
            var attributes = methodInfo.GetCustomAttributes(typeof(MyAttribute), true);
            Assert.IsTrue(attributes.Any(), "MyAttribute found on Index");
            Assert.IsTrue(((MyAttribute)attr[0]).baz);
        }
    }
