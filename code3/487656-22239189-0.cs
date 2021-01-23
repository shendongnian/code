    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PersonExtension; // Don't forget about reference it
    
    namespace UnitTest {
        [TestClass]
        public class UnitTest {
            Person person;
            [TestInitialize]
            public void Init() {
                person = new Person("Person name");
            }
    
            [TestMethod]
            public void TestRename() {
                Assert.AreEqual("Person name", person.Name);
                person.Rename("New name");
                Assert.AreEqual("New name", person.Name);
            }
        }
    }
