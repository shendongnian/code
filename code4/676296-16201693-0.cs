    public static void Parse( )
    {
       using( var sw = new StreamWriter(@"c:\file.txt") )
       { 
           foreach (string sf in ff)
           {
               if (File.Exists(sf))
                  File.Move(sf, copy_dir + "\\" + sf);
               else
                  Print( sw, "Error: " + sf + " not found");
           }
       }
    }
 
    public static void Print(StreamWriter s, string log)
    {
        DateTime ts = DateTime.UtcNow;
        s.WriteLine(ts + " " + log);
    }
   
