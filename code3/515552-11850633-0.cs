    using (BinaryReader binReader = new BinaryReader(File.Open("input.db", 
                                                     FileMode.Open))) 
    {
        byte[] bytes = binReader.ReadBytes(int.MaxValue); // See note below
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.Close();
        Response.End();
    }
