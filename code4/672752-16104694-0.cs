    int startIndex // you have already assigned this somewhere
                   // it's the starting index of this line
    using (FileStream fs = new FileStream("path to file", FileMode.Create, FileAccess.Write))
    {
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            bw.Position = startIndex
            bw.Write(Encoding.Default.GetBytes(line), 0, line.Length);
        }
    }
