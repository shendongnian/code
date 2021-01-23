    int counter = 0;
    string line;
    
    // Read the file and display it line by line.
    using (StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    {
    List<string> items = new List<string>();
    while((line = file.ReadLine()) != null)
     {
       if (!line.Trim().StartsWith("#") && !line.Trim().StartsWith("0"))
       {
         string[] arr = line.Split('\t');  //each item
         items.Add(line);                  //or if you want the whole row
       } 
    
       counter++;
     }    
    }
