    using(StreamReader reader = tsharkProcess.StandardOutput)
    {
       while (!reader.EndOfStream)
       {
           string[] values = reader.ReadLine().Split('\t');
           if (values.Length == 4)
           {
               string ipAddress = values[0];
               string value = values[1];
               string percentage = values[3];
               ...
           }
       }
    }
