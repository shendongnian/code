     public static bool getAllDocuments()
     {
         Console.WriteLine("getAllDocuments debug, START");
         bool isOK = false;
         string baseUrl = "http://jabdw3421:82/sites/TestSite/";
         try
         {
             SPSecurity.RunWithElevatedPrivileges(delegate()
             {
                 using (SPSite site = new SPSite(baseUrl))
                 {
                     using (SPWeb web = site.OpenWeb())
                     {
                         SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["TestLib"];
                         IEnumerable<SPFile> allFiles = ExploreFolder(lib.RootFolder);
     
                         foreach (SPFile file in allFiles)
                         {
                             Console.WriteLine("getAllDocuments debug, File Name : " + file.Name);
                             Console.WriteLine("getAllDocuments debug, File CharSetName : " + file.CharSetName);
                             Console.WriteLine("getAllDocuments debug, File SourceLeafName : " + file.SourceLeafName);
                         }
                     }
                 }
             });
         }
         catch (Exception e)
         {
             Console.WriteLine("getAllDocuments debug, " + e.Message);
             isOK = false;
         }
         Console.WriteLine("getAllDocuments debug, END");
         return isOK;
     }
     
     private static IEnumerable<SPFile> ExploreFolder(SPFolder folder)
     {
         foreach (SPFile file in folder.Files)
         {
             yield return file;
         }
         foreach (SPFolder subFolder in folder.SubFolders)
         {
             foreach (SPFile file in ExploreFolder(subFolder))
             {
                 yield return file;
             }
         }
     }
