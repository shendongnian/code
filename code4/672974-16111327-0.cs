      static void DirSearch(string sDir)
      {
           try
           {
               foreach (string d in Directory.GetDirectories(sDir))
               {
                   foreach (string f in Directory.GetFiles(d))
                   {
                       File.Delete(f);
                   }
                   DirSearch(d);
               }
           }
           catch (System.Exception excpt)
           {
               Console.WriteLine(excpt.Message);
           }
      }
