     Directory.CreateDirectory("Public\\Html");
         Directory.CreateDirectory("\\Users\\User1\\Public\\Html");
         Directory.CreateDirectory("c:\\Users\\User1\\Public\\Html"); // using verbatim string you can escape slashes
    if(System.IO.Directory.Exists(yourPath))
    {
      Directory.CreateDirectory(yourPath);
    }
