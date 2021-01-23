    private byte[] ReadFully(Stream input)
    {
        try
        {
            int bytesBuffer = 1024;
            byte[] buffer = new byte[bytesBuffer];
            using (MemoryStream ms = new MemoryStream())
            {
                int readBytes;
                while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                   ms.Write(buffer, 0, readBytes);
                }
                return ms.ToArray();
            }
        }
        catch (Exception ex)
        {
            // Exception handling here:  Response.Write("Ex.: " + ex.Message);
        }
    }
