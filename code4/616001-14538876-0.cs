    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open("path"))
    {
        bw.BaseStream.Position = 0xB000; // set the offset
        bw.Write(new Guid.NewGuid());
    }
