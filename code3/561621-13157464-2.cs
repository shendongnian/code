     [TestFixture]
        public class RouteRegistrarBespokeTests
        {
            private UrlHelper _urlHelper;
    
            [SetUp]
            public void SetUp()
            {
                var routes = new RouteCollection();
                routes.Clear();
                var routeData = new RouteData();
                RegisterRoutesTo(routes);
                var requestContext = new RequestContext(HttpMocks.HttpContext(), 
                                               routeData);
                _urlHelper = new UrlHelper(requestContext, routes);
            }
    
            [Test]
            public void Should_be_able_to_map_sample_without_user()
            {
                var now = DateTime.Now;
                var result = _urlHelper.Action("Index", "Sample", 
                                   new {  year = now.Year, month = now.Month });
                Assert.AreEqual(string.Format("/Sample/{0}-{1}/Index", 
                                          now.Month, now.Year ), result);
            }
    
            [Test]
            public void Should_be_able_to_map_sample_with_user()
            {
                var now = DateTime.Now;
                var result = _urlHelper.Action("Index", "Sample", 
                              new { user = "user1", year = now.Year, 
                                    month = now.Month });
                Assert.AreEqual(string.Format("/Sample/{0}-{1}/Index/{2}", 
                                         now.Month, now.Year, "user1"), result);
            }
   
                 
    private static void RegisterRoutesTo(RouteCollection routes)
    {
        routes.MapRoute("route1", "{controller}/{month}-{year}/{action}/{user}");
        routes.MapRoute("route2", "{controller}/{month}-{year}/{action}");
    }
                
    }
