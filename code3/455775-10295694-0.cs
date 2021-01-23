    if (Clipboard.ContainsFileDropList())
    {
         // Get a list of files
         System.Collections.Specialized.StringCollection returnList = Clipboard.GetFileDropList();
         // For each file in the list
         foreach(string s in returnlist)
         {
             // split the file path and get the last node of the path which should be file.ext
             String[] sa = s.Split('\');
             string sourceFile = s;
             // set the file target
             string targetFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop))+sa[sa.length-1];
             // Get a list of files
             System.IO.File.Copy(sourceFile, destFile, true); // finally copy the file
         }
     }
