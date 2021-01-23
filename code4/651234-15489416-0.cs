    private void Create_File(string directory, string filenameWithoutExtension )
    {
        // You can just call it - it won't matter if it exists
        System.IO.Directory.CreateDirectory(directory);
        string fileName = filenameWithoutExtension + ".txt";
        string pathString = System.IO.Path.Combine(directory, fileName);
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(pathString))
        {
            file.WriteLine(Some_Method(MP.Mwidth, MP.Mheight, MP.Mtype, "" )); 
        }
    }
