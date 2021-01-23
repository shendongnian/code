    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open("path"))
    {
        bw.BaseStream.Position = 0xB8EB9; // set the offset
        bw.Write(Guid.NewGuid());
    }
