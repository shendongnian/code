    using System;
    using GetPropertiesSample.ReportService2010;
    using System.Diagnostics;
    using System.Collections.Generic;	//<== required for LISTS
    using System.Reflection;
    namespace GetPropertiesSample
    {
    class Program
    {
        static void Main(string[] args)
        {
            GetListOfObjectsInGivenFolder_and_ResetTheReportDataSource("0_Contacts");  //<=== This is the parent folder
        }
        private static void GetListOfObjectsInGivenFolder_and_ResetTheReportDataSource(string sParentFolder)
        {
            // Create a Web service proxy object and set credentials
            ReportingService2010 rs = new ReportingService2010();
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            CatalogItem[] reportList = rs.ListChildren(@"/" + sParentFolder, true);
            int iCounter = 0;
            foreach (CatalogItem item in reportList)
            {
                iCounter += 1;
                Debug.Print(iCounter.ToString() + "]#########################################");
                if (item.TypeName == "Report")
                {
                    Debug.Print("Report: " + item.Name);
                    ResetTheDataSource_for_a_Report(item.Path, "/DataSources/Shared_New");   //<=== This is the DataSource that I want them to use
                }
            }
        }
        private static void ResetTheDataSource_for_a_Report(string sPathAndFileNameOfTheReport, string sPathAndFileNameForDataSource)
        {
            //from: http://stackoverflow.com/questions/13144604/ssrs-reportingservice2010-change-embedded-datasource-to-shared-datasource
            ReportingService2010 rs = new ReportingService2010();
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            
            string reportPathAndName = sPathAndFileNameOfTheReport;
            //example of sPathAndFileNameOfTheReport  "/0_Contacts/207_Practices_County_CareManager_Role_ContactInfo";
            
            List<ReportService2010.ItemReference> itemRefs = new List<ReportService2010.ItemReference>();
            ReportService2010.DataSource[] itemDataSources = rs.GetItemDataSources(reportPathAndName);
            foreach (ReportService2010.DataSource itemDataSource in itemDataSources)
            {
                ReportService2010.ItemReference itemRef = new ReportService2010.ItemReference();
                itemRef.Name = itemDataSource.Name;
                
                //example of DataSource i.e. 'itemRef.Reference':    "/DataSources/SharedDataSource_DB2_CRM";
                itemRef.Reference = sPathAndFileNameForDataSource;
                
                itemRefs.Add(itemRef);
            }
            rs.SetItemReferences(reportPathAndName, itemRefs.ToArray());
        }
    }
}
