    private static string GetSaveFilename(string destinationFolder, string baseName, string extension)
    {
        StringBuilder name = new StringBuilder(destinationFolder + baseName);
        if (System.IO.File.Exists(name.ToString() + extension))
        {
            int counter = 1;
            while (System.IO.File.Exists(name.ToString() + "_" + counter + extension))
            {
                counter++;
            }
            name.Append("_" + counter);
        }
        name.Append(extension);
        return name.ToString();
    }
