        [TestMethod]
        public void Home_Index_test_with_no_Parameter()
        {
            var context = new StubHttpContextForRouting(requestUrl: "~/");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            // Act
            var routeData = routes.GetRouteData(context);
            // Assert
            Assert.IsNotNull(routeData, "~/ url is getting routed properly");
            Assert.AreEqual("Home", routeData.Values["controller"],
                            "~/ url is not getting routed properly");
            Assert.AreEqual("index", routeData.Values["action"], "~/ url is not getting routed properly");
        }
