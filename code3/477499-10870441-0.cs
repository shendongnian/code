    String bits = "01001001000......0001100100"; // shortened here for demo purposes
    byte[] bArr = new byte[bits.Length / 8];
    for (int i = 0; i < bits.Length / 8; i++)
    {
        String part = bits.Substring(i * 8, 8);
        bArr[i] += Convert.ToByte(part, 2);
    }
    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    Console.WriteLine(encoding.GetString(bArr));
