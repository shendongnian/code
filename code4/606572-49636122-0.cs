    using System;
    using System.IO;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            public static void Main(string[] args)
            {
                // Create a header for your text file
                string[] HeaderA = { "****** List of Files ******" };
                System.IO.File.WriteAllLines(@"c:\Folder1\ListOfFiles.txt", HeaderA);
    
                // Get all files from a folder and all its sub-folders. Here we are getting all files in the folder
                // named "Folder2" that is in "Folder1" on the C: drive. Notice the use of the 'forward and back slash'.
                string[] arrayA = Directory.GetFiles(@"c:\Folder1/Folder2", "*.*", SearchOption.AllDirectories);
                {
                    //Now that we have a list of files, write them to a text file.
                    WriteAllLines(@"c:\Folder1\ListOfFiles.txt", arrayA);
                }
    
                // Now, append the header and list to the text file.
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"c:\Folder1\ListOfFiles.txt"))
                {
                    // First - call the header 
                    foreach (string line in HeaderA)
                    {
                        file.WriteLine(line);
                    }
    
                    file.WriteLine(); // This line just puts a blank space between the header and list of files. 
    
    
                    // Now, call teh list of files.
                    foreach (string name in arrayA)
                    {
                        file.WriteLine(name);
                    }
    
                }
              }
    
    
            // These are just the "throw new exception" calls that are needed when converting the array's to strings. 
    
            // This one is for the Header.
            private static void WriteAllLines(string v, string file)
            {
                //throw new NotImplementedException();
            }
    
            // And this one is for the list of files. 
            private static void WriteAllLines(string v, string[] arrayA)
            {
                //throw new NotImplementedException();
            }
           
    
    
        }
    }
