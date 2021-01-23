    var paths = new[]
    {
       @"C:\Temp",
       @"\\Temp",
       "Temp",
       "/Temp",
       "~/Temp",
       "file://C:/Temp",
       "file://Temp",
       "http://something/Temp"
    };
    
    foreach (string p in paths)
    {
       Uri uri;
       if (!Uri.TryCreate(p, UriKind.RelativeOrAbsolute, out uri))
       {
          Console.WriteLine("'{0}' is not a valid URI", p);
       }
       else if (!uri.IsAbsoluteUri)
       {
          Console.WriteLine("'{0}' is a relative URI", p);
       }
       else if (uri.IsFile)
       {
          if (uri.IsUnc)
          {
             Console.WriteLine("'{0}' is a UNC path", p);
          }
          else
          {
             Console.WriteLine("'{0}' is a file URI", p);
          }
       }
       else
       {
          Console.WriteLine("'{0}' is an absolute URI", p);
       }
    }
