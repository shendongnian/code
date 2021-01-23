    static FolderData GetOrCreateFolder(List<string> folders, 
                                        FolderData root,
                                        SessionAwareCoreService2010Client client)
    {
        var filter = new OrganizationalItemItemsFilterData();
        filter.ItemTypes = new [] { ItemType.Folder };
        var items = client.GetListXml(root.Id, filter).
                               Elements(TRIDION_NAMESPACE + "Item");
        foreach (var element in items)
        {
            if (folders.Count == 0)
            {
                break; // break from foreach
            }
            var titleAttribute = element.Attribute("Title");
            var idAttribute = element.Attribute("ID");
            if (titleAttribute != null && titleAttribute.Value == folders[0] && 
                idAttribute != null)
            {
                // folder exists
                FolderData fd = client.Read(idAttribute.Value, 
                                            EXPANDED_READ_OPTIONS) as FolderData;
                // We just took care of this guy, remove it to recurse
                folders.RemoveAt(0);
                return GetOrCreateFolder(folders, fd, client);
            }
        }
        if (folders.Count != 0)
        {
            //Folder doesn't exist, lets create it and return its folderdata
            var newfolder = new FolderData();
            newfolder.Title = folders[0];
            newfolder.LocationInfo = new LocationInfo { 
                OrganizationalItem = new LinkToOrganizationalItemData { 
                    IdRef = root.Id 
                }
            };
            newfolder.Id = "tcm:0-0-0";
            var folder = client.Create(newfolder, EXPANDED_READ_OPTIONS) 
                                   as FolderData;
            folders.RemoveAt(0);
            if (folders.Count > 0)
            {
                folder = GetOrCreateFolder(folders, folder, client);
            }
            return folder;
        }
        return root;
    }
