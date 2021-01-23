    TextReader reader = new StreamReader(stream);
    string line;
    StringBuilder sb = new StringBuilder();
    while ((line = reader.ReadLine()) != null)
    {
        if (someCondition)
        {
           //Change variable line as you wish.
        }
        sb.Append(line);
     }
    using (StreamWriter sw = new StreamWriter("filePath"))
    {
        sw.Write(sb.ToString());
    }
