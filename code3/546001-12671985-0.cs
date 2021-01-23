    // Character stream writing
    StreamWriter writer = File.CreateText("c:\\myfile.txt"); 
    writer.WriteLine("Out to file."); 
    writer.Close();
    
    // Character stream reading
    StreamReader reader = File.OpenText("c:\\myfile.txt"); 
    string line = reader.ReadLine(); 
    while (line != null) {
      Console.WriteLine(line); 
      line = reader.ReadLine(); 
    } 
    reader.Close();
