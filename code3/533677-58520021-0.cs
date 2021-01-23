    using System;
    using System.IO;
     
    class MainClass {
      public static void Main (string[] args) {
        
        using (StreamWriter file = new StreamWriter(@"WriteLines2.txt"))
        {
            file.WriteLine("This is a test line !");
        }
        
        var dir = @"/";
        DirectorySearch(dir, new string[] {"tmp"});
      }
      
      
      public static void DirectorySearch(string dir, string[] excludedDirs = null , int lvl = 3, string spacer = "")
      {
        excludedDirs = excludedDirs ?? new string[0];
        foreach (string f in Directory.GetFiles(dir))
        {
            Console.WriteLine(spacer+Path.GetFileName(f));
        } 
        foreach (string d in Directory.GetDirectories(dir))
        {
            Console.WriteLine(spacer+"-"+Path.GetFileName(d));
            if(lvl>0 && Array.IndexOf(excludedDirs, Path.GetFileName(d)) < 0)
            {
              DirectorySearch(d, excludedDirs, lvl-1, spacer+"  ");
            }
        }
      }
    }
