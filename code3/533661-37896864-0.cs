         try
         {
             foreach (string f in Directory.GetFiles(dir))
             {
                 Console.WriteLine(Path.GetFileName(f));
             }
             foreach (string d in Directory.GetDirectories(dir))
             {
                 Console.WriteLine(Path.GetFileName(d));
                 DirectorySearch(d);
             }
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
     }
