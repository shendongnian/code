    public byte[] functionThatCombinesBytes(Queue<byte[]> data)
    {
        using (var memoryStream = new MemoryStream())
        {
            foreach (var segment in data)
            {
                memoryStream.Write(segment, 0, segment.Length);
            }
            return memoryStream.ToArray();
        }
    }
