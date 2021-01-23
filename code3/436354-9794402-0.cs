    static void Main(string[] args)
    {
         string path = @"C:\Users\Admin";
         DirectoryInfo dir = new DirectoryInfo(path); 
         FileInfo[] files = null;
         try {
                files = dir.GetFiles();
         }
         catch (AccessDeniedException ex) {
             // do something and return
             return;
         }
    
         //else continue
         foreach (FileInfo fil in files )
         {
            //At dir.GetFiles, I get an error  saying
            //access to the string path is denied.
    
             Console.WriteLine(fil.Name);
          }
          Console.ReadLine();
    }
