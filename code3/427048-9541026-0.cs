    using (TextWriter writer = new StreamWriter(tmpFilePath, Ecoding.UTF8))
    {
     using (TextReader reader = new StreamReader(answer, Encoding.GetEncoding("ISO-8859-1")))
     {
       while ((line = reader.ReadLine()) != null) 
       {
          writer.WriteLine(decoded_line);
       }
     }    
    }
