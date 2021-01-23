        byte[] data = new byte[] { 1, 3, 5, 7, 9 };  // sample data
        IList<byte[]> temp = new List<byte[]>(data.Length);
        float biggest = 0; ;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] > biggest)
                biggest = data[i];
        }
        for (int i = 0; i < data.Length; i++)
        {
            temp.Add(BitConverter.GetBytes(data[i] * (1 / biggest)));
        }
