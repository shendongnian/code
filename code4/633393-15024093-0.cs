                // This will contain all information about the path
                DirectoryInfo infoDir = new DirectoryInfo(@"C:\Users\Administrator\Pictures2\WallPaperHD - 078.jpg");
    
                // Root folder passed => Default in SharePoint
                if (infoDir.Parent != null)
                {
                    // All folders are stored here
                    List<string> folders = new List<string>();
    
                    // Set current folder to parent
                    DirectoryInfo currentDir = infoDir.Parent;
                    do
                    {
                        // Add its name to array
                        folders.Add(currentDir.Name);
    
                        // Set parent of current as current if available
                        if (currentDir.Parent != null)
                            currentDir = currentDir.Parent;
                    }
                    while (currentDir.Parent != null);
    
                    // Add SP structure)
                    using (SPSite site = new SPSite("http://testsite.dev"))
                    {
                        SPWeb web = site.RootWeb;
                        // Get doc library
                        SPList documentLibrary = web.GetList("/UserDocuments");
                        // If library root exists
                        if (documentLibrary != null)
                        {
                            string folderUrl = "/UserDocuments/";
    
                            for (int i = folders.Count - 1; i >= 0; i--)
                            {
                                string folder = folders[i];
                                SPFolder newFolder = site.RootWeb.GetFolder(folderUrl + folder);
                                if (!newFolder.Exists)
                                {
                                    site.RootWeb.Folders.Add(folderUrl + folder);
                                    // Save changes
                                    site.RootWeb.Update();
    
                                    folderUrl += folder + "/";
                                }
                            }
                        }
                    }
                }
