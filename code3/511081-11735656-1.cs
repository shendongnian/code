    string ip = "192.168.12.1";
    StringBuilder stringBuilder = new StringBuilder();
    string[] array = ip.Split('.');
                
    foreach (string subsection in array)
    {
          if (subsection.Length < 2)
                 stringBuilder.Append("00" + subsection);
          else if (subsection.Length < 3)
                 stringBuilder.Append("0" + subsection);
          else
                 stringBuilder.Append(subsection);
    }
    
