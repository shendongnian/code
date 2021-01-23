    public Folder GetPublicFolderByPath(ExchangeService service, String ewsFolderPath)
        {
            String[] folders = ewsFolderPath.Split('\');
            
            Folder parentFolderId = null;
            Folder actualFolder = null;
            for (int i = 0; i < folders.Count(); i++)
            {
                if (0 == i)
                {
                    parentFolderId = GetTopLevelFolder(service, folders[i]);// for first first loop public folder root is the parent
                    actualFolder = parentFolderId; //in case folders[] is only one long
                }
                else
                {
                    actualFolder = GetFolder(service, parentFolderId.Id, folders[i]);
                    parentFolderId = actualFolder;
                }
            }
            return actualFolder;
        }
