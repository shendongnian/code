    void WriteColorsToFile(string path, Color[] colors)
    {
        BinaryWriter writer = new BinaryWriter(File.OpenWrite(path));
    
        writer.Write(colors.Length);
    
        foreach(Color color in colors)
        {
            writer.Write(color.ToArgb());
        }
    
        writer.Close();
    }
    
    Color[] ReadColorsFromFile(string path)
    {
        BinaryReader reader = new BinaryReader(File.OpenRead(path));
    
        int length = reader.ReadInt32();
    
        Colors[] result = new Colors[length];
    
        for(int n=0; n<length; n++)
        {
            result[n] = Color.FromArgb(reader.ReadInt32());
        }
    
        reader.Close();
    }
