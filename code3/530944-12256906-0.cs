    string files = "C:\Hello; C:\Hi; D:\Goodmorning; D:\Goodafternoon; E:\Goodevening";
    //Get each path and remove whitespaces
    string[] paths = files.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    //Use xmlLoc for adding \ to each file
    List<string> xmlLoc = new List<string>();
    //get the files in directories
    string[] getFiles;
    //Add \ each paths variable and store it in xmlLoc list
    foreach (string s in paths)
    {
         xmlLoc.Add(s + @"\");
    }
    //get the xml files of each directory in xmlLoc and loop it to read the files
    foreach (string directory in xmlLoc)
    {
         getFiles = Directory.GetFiles(directory, "*.xml");
         foreach(string files in getFiles)
         {
             MessageBox.Show(files);
         }
    }
