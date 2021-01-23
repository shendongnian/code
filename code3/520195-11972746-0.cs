    var tfsUri = new Uri("http://localhost:8080/tfs/");
    var tfsConfigServer = new TfsConfigurationServer(tfsUri, new UICredentialsProvider());
    tfsConfigServer.EnsureAuthenticated();
    
    var projCollectionNode = tfsConfigServer.CatalogNode.QueryChildren(new[] {CatalogResourceTypes.ProjectCollection}, false,                                                               CatalogQueryOptions.None).FirstOrDefault();
    var collectionId = new Guid(projCollectionNode.Resource.Properties["InstanceId"]);
    var projCollection = tfsConfigServer.GetTeamProjectCollection(collectionId);
    
    ITestManagementService tms = projCollection.GetService<ITestManagementService>();
    var project = tms.GetTeamProject("TfsVersioning");
    
    var testCase = project.TestCases.Create();
    testCase.Title = "Browse my blog";
    var navigateToSiteStep = testCase.CreateTestStep();
    navigateToSiteStep.Title = "Navigate to \"http://www.ewaldhofman.nl\"";
    testCase.Actions.Add(navigateToSiteStep);
    
    var clickOnFirstPostStep = testCase.CreateTestStep();
    clickOnFirstPostStep.Title = "Click on the first post in the summary";
    clickOnFirstPostStep.ExpectedResult = "The details of the post are visible";
    testCase.Actions.Add(clickOnFirstPostStep);
    testCase.Save();
    
    //Add test case to an existing test suite
    var plans = project.TestPlans.Query("SELECT * FROM TestPlan where PlanName = 'TfsVersioning Test Plan'");
    var plan = plans.First();
    var firstMatchingSuite = project.TestSuites.Query("SELECT * FROM TestSuite where Title = 'ExampleSuite2'").First();
    ((IStaticTestSuite)firstMatchingSuite).Entries.Add(testCase);
    plan.Save();
