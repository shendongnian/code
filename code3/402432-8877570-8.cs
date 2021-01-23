    List<string> DirSearch(string sDir) 
    {
       List<string> files = new List<string>();
       try	
       {
          foreach (string f in Directory.GetFiles(d)) 
          {
             files.Add(f);
          }
          foreach (string d in Directory.GetDirectories(sDir)) 
          {
             files.AddRange(DirSearch(d));
          }
       }
       catch (System.Exception excpt) 
       {
          Console.WriteLine(excpt.Message);
       }
       return files;
    }
