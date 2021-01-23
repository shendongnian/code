    using ... //Here you reference the namespace where "Person" is
    [TestFixture]
    public class PersonTests {
        [Test]
        public void TestFoo() {
            //You should be able to access the class you want to test from here
            var person = new Person(); 
            
            //Assert here...
        }
    
    }
