    int width = sizeof(float);
    byte[] data = new byte[myData.Count * width];
    for (int i = 0; i < myData.Count; ++i)
    {
        byte[] converted = BitConverter.GetBytes(myData[i]);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(converted);
        }
        for (int j = 0; j < width; ++j)
        {
            data[i * width + j] = converted[j];
        }
    }
