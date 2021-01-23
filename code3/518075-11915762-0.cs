    var input = 16;
    var bytes = new byte[2];
    bytes[0] = (byte)(input >> 8);  // 0x00
    bytes[1] = (byte)input;         // 0x10
    var result = (bytes[0] << 8)
               | bytes[1];
    // result == 16
