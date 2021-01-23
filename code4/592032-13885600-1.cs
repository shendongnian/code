    using(StreamReader reader = tsharkProcess.StandardOutput)
    {
       while (!reader.EndOfStream)
       {
           string row = reader.ReadLine().Split('\t');
           string[] values = RegEx.Split(row, "\s+", RegExOptions.None);
           if (values.Length == 4)
           {
               string ipAddress = values[0];
               string value = values[1];
               string percentage = values[3];
               ...
           }
       }
    }
