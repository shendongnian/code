			using GPMGMTLib;
			
			
			GPM groupPolicyManagement = new GPM();
            IGPMConstants groupPolicyConstants = groupPolicyManagement.GetConstants();
			GPMRSOP rsop = groupPolicyManagement.GetRSOP(groupPolicyConstants.RSOPModeLogging, null, 0);
			rsop.LoggingComputer = "MyComputer";
			rsop.LoggingUser = "domain\\user";
            rsop.CreateQueryResults();
            rsop.GenerateReportToFile(groupPolicyConstants.ReportXML, "C:\\Temp\\test.xml");
