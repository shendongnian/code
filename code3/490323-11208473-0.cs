        GetFileInfo(string dir)
    {
     try
           {
               FileInfo info = null;
               foreach (string d in Directory.GetDirectories(sDir))
               {
                   foreach (string file in Directory.GetFiles(d))
                   {
                    info =  new FileInfo(file);
                    //get all information using info here
                   }
                   GetFileInfo(d);
               }
           }
           catch (System.Exception excpt)
           {
               Console.WriteLine(excpt.Message);
           }
    }
