    public static void ExportFile(string fileName, string content)
    {
        byte[] fileContent = Convert.FromBase64String(content);
        using (FileStream file = new FileStream(fileName, FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(file))
            {
                writer.Write(fileContent,0,fileContent.Length);
                writer.Close();
            }
    
            file.Close();
        }
    }
