    TextReader reader = new StreamReader(stream);
    string line;
    String newLines[];
    int index = 0;
    while ((line = reader.ReadLine()) != null)
    {
       if (someCondition)
       {
          //Change variable line as you wish.
       }
       newLines[index] = line;
       index++;
    }
    using (StreamWriter sw = new StreamWriter("filePath"))
    {
        foreach (string l in newLines)
        {
            sw.WriteLine(l);
        }
    }
