    string[] values = RxString.Split(new Char[] {','}); 
    foreach(String value in values)
    {
       string[] parts = value.Split(new char[] {'.'});
       if (parts.Length == 2)
       {
          int v;
          if (int.TryParse(parts[0], out v))
          {
              // do something with v
          }
       }
    }
