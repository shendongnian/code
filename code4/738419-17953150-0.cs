    var headerBytes = new List<Byte[]>();
    UInt64 PayloadSize = (UInt64)payLoad.Length;
    //write the first byte (FFragment + RSV1,2,3 + op-code(4-bit))
    byte firstHeaderByte = 129; // 1000 0001
    headerBytes.Add(new byte[] { firstHeaderByte });
    if (PayloadSize <= 125)
    {
        // the second byte is made up by 1 + 7 bit.
        // the first bit has to be 1 as a client must always use a client
        byte[] bytes = new byte[] { Convert.ToByte(payLoad.Length + 128) };
        Array.Reverse(bytes);
        headerBytes.Add(bytes);
    }
    else if (PayloadSize >= 126 && PayloadSize <= ushort.MaxValue)     
    {
        var data = new byte[1];
        data[0] = 126 + 128;
        headerBytes.Add(data);
        data = BitConverter.GetBytes(Convert.ToUInt16(PayloadSize));
        Array.Reverse(data);
        headerBytes.Add(data);
    }
    else
    {
        var data = new byte[1];
        data[0] = 127 + 128;
        headerBytes.Add(data);
        data = BitConverter.GetBytes(Convert.ToUInt64(PayloadSize));
        Array.Reverse(data);
        headerBytes.Add(data);
    }
