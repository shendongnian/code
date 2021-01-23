      static void DirSearch(string sDir)
       {
           try
           {
               foreach (string d in Directory.GetDirectories(sDir))
               {
                   foreach (string f in Directory.GetFiles(d))
                   {
                       //Delete files, but not directories
                       File.Delete(f);
                   }
                   //Recursively call this method, so that each directory
                   //in the structure is wiped
                   DirSearch(d);
               }
           }
           catch (System.Exception excpt)
           {
               Console.WriteLine(excpt.Message);
           }
       }
