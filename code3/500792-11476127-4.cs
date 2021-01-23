    byte[] field1Bytes = { 0x06, 0x90, 0x04, 0x60, 0x42, 0x00, 0x06, 0x14, 0x92, 0x31 } ;
    byte[] field2Bytes = { 0x01, 0x30, 0x50, 0x01, 0x03, 0x00, 0x10, 0x00, 0x00 } ;
    byte separator = 13; // D  0x0D 
    byte[] result = new byte[field1Bytes.Length + field2Bytes.Length];
       
    Array.Copy(field1Bytes, 0, result, 0, field1Bytes.Length);
    Array.Copy(field2Bytes, 0, result, field1Bytes.Length, field2Bytes.Length);
    // shift the separator into the first byte of the second array in the result
    result[field1Bytes.Length] |= (byte)(separator << 4);
