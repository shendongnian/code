    public delegate void FileNotFoundCallback(string file);
    public void MergeClientFiles(string directory, FileNotFoundCallback callback)
    {
        // Find all clients
        Array clients = Enum.GetValues(typeof(Clients));
        // Create a new array of files
        string[] files = new string[clients.Length];
        // Combine the clients with the .txt extension
        for (int i = 0; i < clients.Length; i++)
            files[i] = clients.GetValue(i) + ".txt";
        // Merge the files into directory
        using (var output = File.Create(directory))
        {
            foreach (var file in files)
            {
                try
                {
                    using (var input = File.OpenRead(file))
                    {
                        input.CopyTo(output);
                    }
                }
                catch (FileNotFoundException)
                {
                    // Its here I want to send the error to the form
                    callback( file );
                    continue;
                }
            }
        }
    }
