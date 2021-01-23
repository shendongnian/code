        string pathfile = @"C:\Users\Public\Documents\Filepath.txt";  
      if    (File.Exists(pathfile)) 
       {
                         
                         File.Delete(pathfile);
                         
         
                     }
                     if (!File.Exists(pathfile))
                     {
                         
         
                         using (FileStream fs = File.Create(pathfile))
                       
                         {
                             Byte[] info = new UTF8Encoding(true).GetBytes("Your Text Here");
                                                
                             fs.Write(info, 0, info.Length);
                           
                             
                             FileSecurity fsec = File.GetAccessControl(pathfile);
                             fsec.AddAccessRule(new FileSystemAccessRule("Everyone",
                             FileSystemRights.FullControl, AccessControlType.Deny));
                             File.SetAccessControl(pathfile, fsec);
         
                         }
         
         
                         }
