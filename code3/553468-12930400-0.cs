    [TestClass]
    public class MultipleReturnValues {
        public class ValidUserContext {
            public string Principal { get; set; }
        }
        public interface IMembershipService {
            ValidUserContext ValidateUser(string name, string password);
        }
        [TestMethod]
        public void DifferentPricipals() {
            var mock = new Mock<IMembershipService>();
            mock.Setup(mk => mk.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>(GetUserContext);
            var validUserContext = mock.Object.ValidateUser("abc", "cde");
            Assert.IsNull(validUserContext.Principal);
            validUserContext = mock.Object.ValidateUser("foo", "bar");
            Assert.AreEqual(sPrincipal, validUserContext.Principal);
        }
        private static string sPrincipal = "A Principal";
        private static ValidUserContext GetUserContext(string name, string password) {
            var ret = new ValidUserContext();
            if (name == "foo" && password == "bar") {
                ret = new ValidUserContext { Principal = sPrincipal };
            }
            return ret;
        }
    }
