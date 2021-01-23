    static void Main()
    {
        FileInfo fi = new FileInfo(@"\\path\\to\\file.bak");
        
        if(fi.Exists)
        {
            try
            {
                //because we can still get errors based on permissions etc.
                fi.Delete(); 
                Console.WriteLine("Deleted"); // Success
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex); // Write error
            }  
        }
    }
    
