    byte[] data = {0,0,58,242};
    
    if (BitConverter.IsLittleEndian) {
      Array.Reverse(data);
    }
    int days = BitConverter.ToInt32(data, 0);
    DateTime date = new DateTime(1900, 1, 1).AddDays(days);
    Console.WriteLine(date);
