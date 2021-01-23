Are you looking for System.Text.Encoding?
    for (int i = 0; i < evenParityASCII; i++)
    {
        evenParityASCII[i] = (byte)(evenParityASCII[i] & 0x7F);
    }
    string myAscii = System.Text.Encoding.ASCII.GetString(evenParityASCII);
