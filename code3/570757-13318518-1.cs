    byte[] byteArray = BitConverter.GetBytes(MyDouble);
    string ByteString = System.String.Empty;
    for (int i = 0; i < byteArray.Length; i++)
        ByteString = Convert.ToString(byteArray[i], 2).PadLeft(8, '0');
    
