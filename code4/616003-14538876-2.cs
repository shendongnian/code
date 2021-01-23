    using (System.IO.BinaryWriter fileWriter = new System.IO.BinaryWriter(System.IO.File.Open("path"))
    {
        fileWriter.BaseStream.Position = 0xB8EB9; // set the offset
        fileWriter.Write(Guid.NewGuid());
    }
