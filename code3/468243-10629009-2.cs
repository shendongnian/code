      private void SearchDrives()
      {
    	 foreach (String drive in Directory.GetLogicalDrives())
    	 {
    		try
    		{
    		   // Search for folders into the drive.
    		   SearchFolders(drive);
    		}
    		catch (Exception) { }
    	 }
      }
      //---------------------------------------------------------------------------
    
      private void SearchFolders(String prmPath)
      {
    	 try
    	 {
    		foreach (String folder in Directory.GetDirectories(prmPath))
    		{
    		   // Recursive call for each subdirectory.
    		   SearchFolders(folder);
    
    		   // Create the list of files.
    		   SearchFiles(folder);
    		}
    	 }
    	 catch (Exception) { }
      }
      //---------------------------------------------------------------------------
    
      private void SearchFiles(String prmPath)
      {
    	 try
    	 {
    		foreach (String file in Directory.GetFiles(prmPath))
    		{
    		   FileInfo info = new FileInfo(file);
    		   if (info.Extension == ".txt")
    		   {
    			  listBox1.Items.Add(info.Name); 
    		   }
    		}
    	 }
    	 catch (Exception) { }
      }
      //---------------------------------------------------------------------------
