    TextReader reader = new StreamReader(stream);
    string line;
    StringBuilder sb = new StringBuilder();
    while ((line = reader.ReadLine()) != null)
     {
       if (someCondition)
        {
          // I want to change "line" and save it into the file I'm reading from
        }
       sb.Append(line);
     }
    using (StreamWriter sw = new StreamWriter("filePath"))
    {
        sw.Write(sb.ToString());
    }
