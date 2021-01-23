        public class FooController : ApiController
        {
            public string Get()
            {
                return Url.Link(RouteNames.DefaultRoute, new { controller = "foo", id = "10" });
            }
        }
        [TestFixture]
        public class FooControllerTests
        {
            FooController controller;
            [SetUp]
            public void SetUp()
            {
                var config = new HttpConfiguration();
                
                config.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost");
                request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
                request.Properties[HttpPropertyKeys.HttpRouteDataKey] = new HttpRouteData(new HttpRoute());
                controller = new FooController
                {
                    Request = request
                };
            }
            [Test]
            public void Get_returns_link()
            {
                Assert.That(controller.Get(), Is.EqualTo("http://localhost/api/foo/10"));
            }
        }
