    public class YourController : Controller {
        private readonly IStreamWrapper _streamWrapper;
        public YourController(IStreamWrapper wrapper) {
            _streamWrapper = wrapper;
        }
        public ActionResult MethodYouAreTesting() {
            var result = _streamWrapper.Process(HttpRequest.InputStream);
        }
    }
    public class Tests {
        public void YourTestMethod() {
            var controller = new YourController(new FakeStreamWrapper()); // mock perhaps?
            // Asserts here for the controller action
        }
        public void YourWrapperTester() {
            var wrapper = new RealStreamWrapper();
            // test Process method here..
        }
    }
