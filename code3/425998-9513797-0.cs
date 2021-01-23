    using System;
    using System.IO; 
    class DoStuff 
    {
       char driveLetter;
       ...
       
       void Initialize()
       {
          try
          {
             Directory.SetCurrentDirectory( string(driveLetter)+string(@":\"); 
          }
          catch(IOException e)
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
    
    } 
