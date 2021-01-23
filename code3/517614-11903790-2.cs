    List<string> enumerateFiles = Directory.EnumerateFiles(activeFilepath, "*.*", SearchOption.AllDirectories).ToList();
    
    for (int i = 0; i < enumerateFiles.Count(); i++)
    {
        String filePath = enumerateFiles[i];
    
        // skip the .db file
        if (Path.GetExtension(filePath) != ".db")
        {
            continue;                    
        }
    
        pictureLocations.Add(filePath);
        //pictureLocations[i] = filePath;
    
        // Display an error image if there is a blank entry in the picture location.
        if (pictureLocations[i] == null)
            pictureLocations[i] = @"C:\Users\Public\Pictures\Sample Pictures\error.png";
        //Remove Thumbs.db from the list if read in.
        if (pictureLocations[i] == activeFilepath + @"\Thumbs.db")
        {
            pictureLocations.Remove(pictureLocations[i]);
        }
    }
