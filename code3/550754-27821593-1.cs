    static string GetParentFolder(SPListItem itemToFind, SPFolder folder)  
            { 
               SPQuery query = new SPQuery(); 
               // query.Query =  "<OrderBy><FieldRef Name='Title'/></OrderBy>";
                query.Query = "<Where><Eq><FieldRef Name=\"ID\"/><Value Type=\"Integer\">"+ itemToFind.ID +"</Value></Eq></Where>";
                query.Folder = folder;
                query.ViewAttributes = "Scope=\"Recursive\"";
                SPListItemCollection items = itemToFind.ParentList.GetItems(query);
                int intpartentFolderID=0 ;
                if (items.Count > 0)
                {
                foreach (SPListItem item in items) 
                {
                    SPFile f = item.Web.GetFile(item.Url);
    
                    string test11 = f.ParentFolder.Name;
                    intpartentFolderID = f.ParentFolder.Item.ID;
                    
                    //string test1 = item.File.ParentFolder.Name;
    
                     return (intpartentFolderID.ToString()); 
                            
                 }
                }
                return (intpartentFolderID.ToString());     
            }  
