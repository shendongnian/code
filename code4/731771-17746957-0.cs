    StreamReader sr = new StreamReader("file.txt");
    int counter = 0;
    List<string> arrayFromFile = new List<string>();
    while(string line = sr.ReadLine())
    {
       if(line=='b')
       {
          line = abaArray[counter];
          counter++;
          if(counter>=abaArray.Length)
          {
             counter=0;
          }
       }
       arrayFromFile.Add(line)
    }
    //Write back to the file
