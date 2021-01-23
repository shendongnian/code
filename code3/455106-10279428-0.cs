        // Specify the directories you want to manipulate.
        DirectoryInfo di = new DirectoryInfo(@"c:\MyDir");
        try 
        {
            // Determine whether the directory exists.
            if (di.Exists) 
            {
                // Indicate that it already exists.
                Console.WriteLine("That path exists already.");
                return;
            }
            // Try to create the directory.
            di.Create();
            Console.WriteLine("The directory was created successfully.");
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        } 
        finally {}
