    string[] songspaths = System.IO.Directory.GetFiles(librarypath + "/" + albumpath + "/" + songpath); // Get all the files from the specified directory
    
    List<string> listsongs = new List<string>();
    
    foreach (var f in songspaths)
    {
       lstSong.Items.Add(Path.GetFileNameWithoutExtension(f)); // Store the filename without path or extension in the list
    }
