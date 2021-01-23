        SimpleNameFilter filter = new SimpleNameFilter()
        
        foreach (DataRow DR in DT.Rows)
        {
        string Test = "FullNameOftheTest";
        filter.Add(Test); 
        }
      CoreExtensions.Host.InitializeService();
      TestPackage testPackage = new TestPackage(@"D:\Test\Test.dll");
      RemoteTestRunner remoteTestRunner = new RemoteTestRunner();
      remoteTestRunner.Load(testPackage);
      TestResult result = remoteTestRunner.Run(new NullListener(), filter, true,          LoggingThreshold.All);
      ResultSummarizer summaryResults = new ResultSummarizer(result);
