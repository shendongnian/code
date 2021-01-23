    void ListVirtualDirectories(string serverName, int siteId)
    {            
           DirectoryEntry iisServer = new DirectoryEntry("IIS://" + serverName + "/W3SVC/" + siteId + "/ROOT");
    
           foreach (DirectoryEntry webDir in iisServer.Children)
           {
               if (webDir.SchemaClassName.Equals("IIsWebVirtualDir"))
                   Console.WriteLine("Found virtual directory {0}", webDir.Name);
           }
    }
