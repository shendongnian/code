    //Here you reference the namespace where "Person" is
    using Project.App_Code.Entities;
    namespace Project.UnitTests {
        [TestFixture]
        public class PersonTests {
            [Test]
            public void TestFoo() {
                //You should be able to access the class you want to test from here
                var person = new Person(); 
                
                //Assert here...
            }
        }
    }
