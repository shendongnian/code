    using (FileStream fileStream = new FileStream(@"C:\Help.docx", FileMode.Create, FileAccess.Write))
    {
        using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
        {
            binaryWriter.Write(Properties.Resources.Help);
        }
    }
