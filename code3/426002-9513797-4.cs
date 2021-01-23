      try 
      {
         Process.Start("cmd.exe", @"/k ""cd /d C:\""");
      }
      catch(Exception e)
      { 
          //Just in case...
          Console.WriteLine(e.ToString()); 
          string[] str=Directory.GetLogicalDrives();
          Console.WriteLine( "Using C# Directory Class ,Available drives are:");
          for(int i=0;i< str.Length;i++)
          Console.WriteLine(str[i]);
          //If fatal
          //Environment.Exit(1)
       } 
