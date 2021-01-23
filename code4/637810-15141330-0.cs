     [TestMethod]
       public void TestSiteMap()
       {
          // Arrange
          var tester = new RouteTester<MvcApplication>();
          SiteMapNodeCollection nodes = LoadAllNodes();
          foreach (SiteMapNode node in nodes)
          {
             //check route results
             tester.WithIncomingRequest(node.Url)  ...//do your checks here
          }
       }
