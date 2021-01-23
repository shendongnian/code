            TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("TFS_URL"));
            ITestManagementTeamProject project = tfs.GetService<ITestManagementService>().GetTeamProject("ProjectName");
            var testCase = project.TestCases.Find(1234);
            var testData = testCase.Data.Tables[0];
            this._dataSource = testData.Select();
