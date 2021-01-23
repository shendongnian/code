    public void rename(String path)
    {
      string[] files =System.IO.Directory.GetFiles(path);
      foreach(string s in files)
      {
         string[] ab=s.split('_');
         if(ab.Lenght>3)  
         {
             string newName=ab[1]+ab[3];
             System.IO.File.Move(s,path+newName);
         }
      }
    }
