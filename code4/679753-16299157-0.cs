    string folderid= FindFolder(service, rootFolder,CreatedFolder.Title);
    
    List<ChildReference> listadoFiles = service.Children.List(folderid).Fetch().Items.ToList();
    public static string FindFolder(DriveService service,String parentfolderId, string FolderName)
            {
                ChildrenResource.ListRequest request = service.Children.List(parentfolderId);
                request.Q = "mimeType='application/vnd.google-apps.folder' and title='" + FolderName + "' ";
                            do
                {
                    try
                    {
                        ChildList children = request.Fetch();
    
                        if (children != null && children.Items.Count > 0)
                        {
    
                            return children.Items[0].Id;
                        }
    
                        foreach (ChildReference child in children.Items)
                        {
                            Console.WriteLine("File Id: " + child.Id);
                        }
                        request.PageToken = children.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        request.PageToken = null;
                    }
                } while (!String.IsNullOrEmpty(request.PageToken));
    
                            return string.Empty;
            }
