    public static void CopyTo(this Stream input, Stream output)
    {
        byte[] buffer = new byte[64 * 1024]; // 64K buffer
        int bytesRead;
        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, bytesRead);
        }
    }
