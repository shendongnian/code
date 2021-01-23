    TextReader reader = new StreamReader(stream);
    string line;
    while ((line = reader.ReadLine()) != null)
    {
       if (someCondition)
       {
          //Change variable line as you wish.
       }
       using (StreamWriter sw = new StreamWriter("filePath"))
       {
           sw.WriteLine(line);
       }
     }
