    FileInfo file = new FileInfo("SomeFile");
    using (FileStream inFs = file.OpenRead())
    {
        using (MemoryStream outMs = new MemoryStream())
        {
            encryption.Decrypt(inFs, outMs);                    
            BinaryFormatter bf = new BinaryFormatter();
            targetType target= bf.Deserialize(outMs) as targetType;
        }
    }
