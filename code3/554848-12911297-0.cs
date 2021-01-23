    int writeTimeout = 200;
    using (var aFile = new FileStream(tempFolderPathAlt + saveas + ".xls",    FileMode.Create))
    {
          aFile.WriteTimeout = writeTimeout;
          byte[] byData = package.GetAsByteArray();            
          aFile.Seek(0, SeekOrigin.Begin);            
          aFile.Write(byData, 0, byData.Length);            
          xlWorkSeet1 = null;             
          workBook = null;  
          Thread.Sleep(writeTimeout);
    }
