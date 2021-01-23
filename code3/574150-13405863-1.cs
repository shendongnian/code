    private void AddFileContentsToList(string fileName)
    {
        using(var reader = new System.IO.StreamReader(fileName))
        {
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                AddListBoxItem(line);
            }
        }
    }
