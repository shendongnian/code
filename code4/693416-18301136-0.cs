    using TDAPIOLELib; // This is the QTP interop library 
    private TDConnection qcConnection;
    private string Connect()
    {
        string status;
        status = "Initialising";
            qcConnection.InitConnectionEx("<QC URL>");
            qcConnection.ConnectProjectEx("<QC Domain>", "<QC Project>", "<LoginUserId>", "<UserPassword>");
            if (qcConnection.ProjectConnected)
            {
                status = "Connected";
            }
        return status;
    }
    public void GetTestsInTestSet(string testFolder, string testSetName)
    {
        TDAPIOLELib.List tsTestList = new TDAPIOLELib.List();
        try
        {
            if (qcConnection.ProjectConnected)
            {
                TestSetFactory tSetFact = (TestSetFactory)qcConnection.TestSetFactory;
                TestSetTreeManager tsTreeMgr = (TestSetTreeManager)qcConnection.TestSetTreeManager;
    
                TestSetFolder tsFolder = (TestSetFolder)tsTreeMgr.get_NodeByPath(testFolder);
    
                List tsList = tsFolder.FindTestSets(testSetName, false, null);
    
                
                foreach (TestSet testSet in tsList)
                {
                    TestSetFolder TSFolder = (TestSetFolder)testSet.TestSetFolder;
                    TSTestFactory TSTestFactory = (TSTestFactory)testSet.TSTestFactory;
                    tsTestList = TSTestFactory.NewList("");
                }
    
                foreach (TSTest test in tsTestList)
                {
                    System.Diagnostics.Debug.Writeln(test[qcFrameworkTestIDFieldName]);
                }
    
            }
            else
            {
                Console.WriteLine("QC connection failed");
            }
        }
        catch (Exception e)
        {
            throw e;
        }    
    }
