    public static class Extensions
    {
        public static void Write(this MemoryStream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }
    }
