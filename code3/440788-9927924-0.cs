    For Create a folder use the following code as sample...
    You will have to check if the folder exists of course, this code shows how to create a folder within a folder
    
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
    Here is some code for the methods referenced ....
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CoreWebService.ServiceReference1;
    using CoreWebService.Properties;
    using System.Xml;
    using System.Xml.Serialization;
    
    
    
    namespace CoreWebService
    {
    
        public class CoreServicesUtil
        { 
            public CoreService2010Client coreServiceClient;
            public ReadOptions readOptions;
            /// <summary>
            /// 
            /// </summary>
            public CoreServicesUtil()
            {
                this.coreServiceClient = new CoreService2010Client("basicHttp_2010");
                this.readOptions = new ReadOptions();
            }
    
    
            public  FolderData getFolderData(string tcmuri)
            {
                FolderData folderData = (FolderData)coreServiceClient.Read(tcmuri, readOptions);
                return folderData;
            }
    
        
        }
    
        public static class CoreServicesItemCreator
        {
    
            /**
            * <summary>
            * Name: AddFolder
            * Description: returns a new Folder Data created in the folder Data
            * </summary>
            **/
            public static FolderData AddFolderData(this FolderData folderData)
            {
                FolderData childFolder = new FolderData();
                childFolder.LocationInfo = getLocationInfo(folderData);
                childFolder.Id = "tcm:0-0-0";
                return childFolder;
            }
    
    
         
        }
    }
