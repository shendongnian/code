    string[] songspaths = System.IO.Directory.GetFiles(librarypath + "/" + albumpath + "/" + songpath);
    
    List<string> listsongs = new List<string>();
    
    foreach (var f in songspaths)
    {
       lstSong.Items.Add(Path.GetFileNameWithoutExtension(f));
    }
