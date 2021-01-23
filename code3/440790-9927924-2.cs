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
