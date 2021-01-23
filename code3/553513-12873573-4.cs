    TextReader reader = new StreamReader(stream);
    string line;
    while ((line = reader.ReadLine()) != null)
     {
       if (someCondition)
        {
          // I want to change "line" and save it into the file I'm reading from
        }
       using (StreamWriter sw = new StreamWriter("filePath"))
       {
           sw.WriteLine(line);
        }
     }
