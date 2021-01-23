    //going to set filesGroupList[x] to a string and then see what happens.
    filesGroupList[x] = "First line of string.\nSecond line of string.\n";
    using (StringReader reader = new StringReader(filesGroupList[x]))
    {
      //reader has access to the whole string.
      string line;
      while ((line = reader.ReadLine()) != null)
      {
        //first time through, line is set to "First line of string."
        //second time through, line is set to "Second line of string."
        Console.WriteLine(line);
      }
      //third time through, ReadLine() returns null.
      //line is set to null.
      //filesGroupList[x] is still set to "First line of string.\nSecond line of string.\n"
      Console.WriteLine(line); //outputs an empty line.
      Console.Write(filesGroupList[x]); //outputs whole string (on 2 lines).
    }
    Console.WriteLine(line); //won't compile. line doesn't exist.
    Console.Write(filesGroupList[x]); //outputs whole string (on 2 lines).
