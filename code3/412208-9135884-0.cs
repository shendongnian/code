    using (StreamReader stream = new StreamReader(FileInfo.FullName)) 
    { 
        string line; 
        int i = 0;
        while(!stream.EndOfStream) 
        { 
             i++;
             line = stream.ReadLine();
             if ( i <= 150 ) continue;
             // Do something with the line. 
        }  
    }
