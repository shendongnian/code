    string ip = "192.168.1.1";
    StringBuilder stringBuilder = new StringBuilder();
    string[] array = ip.Split('.');
            
    foreach (string subsection in array)
    {
          if (subsection.Length < 2)
          {
               stringBuilder.Append(subsection.Replace("1", "001"));
          }
          else
          {
               stringBuilder.Append(subsection);
          }
    }
    
