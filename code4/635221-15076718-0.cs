    public void WriteListToFile(Lists lists, string filePath)
    {    
        BinaryFormatter bFormatter = new BinaryFormatter();
    
        // Ppen file for output
        using (FileStream outFile = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
    
            // Output object to file via serialization
            bFormatter.Serialize(outFile, lists);
    
            // Close file
            outFile.Close();
        }
    }
