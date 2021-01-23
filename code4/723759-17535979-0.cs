    try
    {
    	//create searchable object called rootfolder and set root to equal Inbox
    	Folder rootfolder = Folder.Bind(service, WellKnownFolderName.Inbox);
    	//foreach child folder inside Ibox
    	foreach (Folder folder in rootfolder.FindFolders(new FolderView(100)))
    	{
    		//if the child folder is named hey
    		if (folder.DisplayName.Contains("hey"))
    		{
    			//create searchable object of child of root but now is root to be searched within folder and set it as root folder
    			Folder childfolder = Folder.Bind(service, folder.Id);
    			//foreach childfolder to new root
    			foreach (Folder cfolder in childfolder.FindFolders(new FolderView(100)))
    			{
    				//if child folder is blah then search items
    				if (cfolder.DisplayName.Contains("blah"))
    				{
    					//create searchable object of blah folder and set it as root folder
    					FindItemsResults<Item> blah = service.FindItems(cfolder.Id, new ItemView(10));
    					//this will load all the extra properites for each email (SUCH AS BODY)
    					service.LoadPropertiesForItems(from Item item in blah select item, PropertySet.FirstClassProperties);
    					foreach (Item item in blah.Items)
    					{
    					   //Console.WriteLine(item.DateTimeReceived + "\n\t" + item.Body);
    						Console.WriteLine(item.Subject);
    						Console.WriteLine("\t"+item.DateTimeReceived);
    						Console.WriteLine("\t" + item.Body.Text.ToString());
    					}
    				}
    			}
    		}
    	}
    
       
    }
    catch (Exception e)
    {
    	Console.WriteLine(e.Message.ToString());
    }
    Console.ReadLine();
