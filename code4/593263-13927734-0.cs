        //Sample code to list all .cs files within a directory
        string[] filePaths = Directory.GetFiles(@"c:\MyDir\", "*.cs");
        // Sample code to read 1 file. 
        // Read each line of the file into a string array. Each element 
        // of the array is one line of the file. 
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\file1.cs");
        // Display the file contents by using a foreach loop.
        foreach (string line in lines)
        {
            // INSERT YOUR SEARCH LOGIC HERE
        }
  
