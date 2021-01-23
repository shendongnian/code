    string line = ""; 
    System.IO.StreamReader file = new System.IO.StreamReader("c:/test.txt"); 
    List<string> convertedLines = new List<string>(); 
    while ((line = file.ReadLine()) != null) 
    {
        string[] lineSplit = line.Split(','); 
        DateTime dt = new DateTime(); 
        DateTime.TryParse(lineSplit[2], out dt); 
        lineSplit[2] = Convert.ToString(dt.Ticks); 
    　
        string convertedline = lineSplit[0] + "," + lineSplit[1] + "," + lineSplit[2]; 
        convertedLines.Add(convertedline);
    }
    file.Close();
    File.WriteAllLines("c:/newTest.txt", convertedLines);
