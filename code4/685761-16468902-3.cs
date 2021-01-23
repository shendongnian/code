    private void LoadFiles()
    {
        int count = 0;
        if (File.Exists(System.IO.Path.Combine(_Path, _FileName + ".txt")) == false)
            return;
        // load words
        string b = File.ReadAllText(System.IO.Path.Combine(_Path, _FileName + ".txt"));
        
        .....
    }
