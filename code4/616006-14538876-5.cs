    using (System.IO.BinaryWriter fileWriter = new System.IO.BinaryWriter(System.IO.File.Open("path", System.IO.FileMode.Open)))
    {
        fileWriter.BaseStream.Position = 0xB8EB9; // set the offset
        fileWriter.Write(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
    }
