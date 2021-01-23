    private byte[] GetAsByteArray(string BinaryString)
    {
            return Enumerable.Range(0, BinaryString.Length / 8)
                .Select(i => Convert.ToByte(BinaryString.Substring(i * 8, 8), 2)).ToArray();
    }
