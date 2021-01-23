    using(StreamReader reader = tsharkProcess.StandardOutput)
    {
       while (!reader.EndOfStream)
       {
           string row = reader.ReadLine();
           string[] values = Regex.Split(row, @"\s+", RegexOptions.None);
           if (values.Length == 4)
           {
               string ipAddress = values[0];
               string value = values[1];
               string percentage = values[3];
               ...
           }
       }
    }
