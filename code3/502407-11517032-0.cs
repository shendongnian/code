    Public void CopyFiles(string sourcePath,string destinationPath)
    {
         string[] files = System.IO.Directory.GetFiles(sourcePath);
         
         foreach(string file in files)
         {
            System.IO.File.Copy(sourcePath,destinationPath);  
         }
    }
