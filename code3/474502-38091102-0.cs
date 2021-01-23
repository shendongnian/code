    WorkItemStore workitemstore = tfsserv.GetService<WorkItemStore>();
            Project tfsproject = workitemstore.Projects[tfsprojectname];
            ITestManagementService Mtmserveice = (ITestManagementService)tfsserv.GetService(typeof(ITestManagementService));
            ITestManagementTeamProject mtmproj = Mtmserveice.GetTeamProject(tfsproject.Name);
            ITestPlan plan = mtmproj.TestPlans.Find(planid);
            Console.WriteLine("Test Plan: {0}", plan.Name);
            Console.WriteLine("Plan ID: {0}", plan.Id);
            Console.WriteLine("Build Currently In Use: {0}", plan.BuildNumber);
