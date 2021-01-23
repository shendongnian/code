    string filename = "Test.txt";
    try
    {
       using(FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
       {
          // Read content here
       }
    }
    catch(IOException)
    {
        // Occurs if the file cannot be exclusively locked.
    }
