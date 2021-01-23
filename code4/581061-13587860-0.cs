    List<byte> myData = new List<byte>();
    myData.AddRange(Array.Reverse(BitConverter.GetBytes(datam.x));
    myData.AddRange(Array.Reverse(BitConverter.GetBytes(datam.y));
    //....etc....
    byte[] bytesToSend = myData.ToArray();
