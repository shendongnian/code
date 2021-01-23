    string[] splited = requestData.Split(',');
    byte[] resultBytes = new byte[splited.Length];
    
    for (int a = 0; a < splited.Length; a++)
    {
      if (splited[a] == String.Empty)
            continue;
      resultBytes[a] = byte.Parse(splited[a], System.Globalization.NumberStyles.Integer);
    }
