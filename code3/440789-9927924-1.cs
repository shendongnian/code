    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CoreWebService.ServiceReference1;
    
    namespace CoreWebService
    {
        class CoreWebServiceSamples
        {
    
            public static void createFolder()
            {
                string folderWebDavUrl = "/webdav/020%20Content/Building%20Blocks/Content/wstest";
                
                CoreServicesUtil coreServicesUtil = new CoreServicesUtil();
                
                FolderData folderData = coreServicesUtil.getFolderData(folderWebDavUrl);
    
    
                FolderData folderDataChild = folderData.AddFolderData();
                folderDataChild.Title = "childFolder";
               
                folderDataChild = (FolderData)coreServicesUtil.coreServiceClient.Save(folderDataChild, coreServicesUtil.readOptions);
                coreServicesUtil.coreServiceClient.Close();
            }
        }
    }
