    string filename = @"C:\BigTextFile.txt";  
    StreamReader sr = System.IO.File.OpenText(filename);
    
    // Process line by line.  
    string line = "";  
    do  
    {  
    line = sr.ReadLine();  
    }  
    while(sr.Peek() != -1);  
    
    // Load all at once and process.  
    string alltext = sr.ReadToEnd();  
    
    sr.Close();
