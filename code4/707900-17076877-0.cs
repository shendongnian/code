    public ValidFolderPermission(string filePath)
    {
         if(File.Exist(filePath))
         {
              // Open Stream and Read.
              using (FileStream fs = File.Open(filePath, FileMode.Open))
              {
                    byte[] data = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
         
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                          Console.WriteLine(temp.GetString(b));
                    }
               }
         }
    }
