    private void SHA256Directory(string directory)
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo fInfo in files)
            {
                try
                {
                    SHA256 DirectorySHA256 = SHA256Managed.Create();
                    byte[] hashValue;
                    FileStream fStream = fInfo.Open(FileMode.Open);
                    fStream.Position = 0;
                    hashValue = DirectorySHA256.ComputeHash(fStream);
                    Console.WriteLine(fInfo.Name);
                    Miscellaneous.ByteArrayToHex(hashValue);
                    Miscellaneous.ByteArrayToBase64(hashValue);
                    Console.WriteLine();
                    fStream.Close();
                }
                catch (...)
                {
                    // Handle other exceptions here. Through finfo, you can
                    // access the file name
                }
            }
        }
        catch (...)
        {
            // Handle directory/file iteration exceptions here
        }
    }
