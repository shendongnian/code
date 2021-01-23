    bool ok = false; 
    
    while(!ok)
    {
    
    try
    {
         TryWritingToFile();          
       ok = true; 
    }
    catch (Exception)
    {
         CreateFile();
         //now I want to go back and try to write to the file again. 
    }
    }
