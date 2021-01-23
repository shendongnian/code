    public void OpenVersionDialog(string version)
    {
         string mcAD = GetCopyPath(version);
         if(!String.IsNullOrEmpty(mcAD))
         {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "File(*.file)|*.jar|All Files (*.*)|*.*";
                file.Title = "Open File...";
                if (file.ShowDialog() == DialogResult.OK)
                {
                   string fullFileName = item.FileName;
                   FileInfo userSelected = new FileInfo(fullFileName);
                   string fileNameWithExt = Path.GetFileName(fullFileName);
                   string destPath = Path.Combine(Application.UserAppDataPath, fileNameWithExt);
                
                                
                   File.Copy(item.FileName, mcAD, true);
                }
            }
         }
         else
         {
            //invalid version selected
         } 
    }
    public string GetCopyPath(string versionInput)
    {
       //these are case-insensitive checks but you can change that if you want case-sensitive
       if(string.Equals(versionInput, "1.0 Selected", StringComparison.OrdinalIgnoreCase))
          return "YOUR_PATH_FOR 1.0";
    
      if(string.Equals(versionInput, "2.0 Selected", StringComparison.OrdinalIgnoreCase))
          return "YOUR_PATH_FOR 2.0";
    
       if(string.Equals(versionInput, "3.0 Selected", StringComparison.OrdinalIgnoreCase))
          return "YOUR_PATH_FOR 3.0";
       return String.Empty;
    }
