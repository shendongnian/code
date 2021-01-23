    List<string> myValues = new List<string>();
    string line;    
    // Read the file and display it line by line.
    System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       myValues.Add(line);
    }
