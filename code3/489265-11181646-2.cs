    public byte[] GetBytesFrom(string hex)
    {
        var length = hex.Length / 2;
        var result = new byte[length];
        for (var i = 0; i < length; i++)
        {          
          result[i] = byte.Parse(hex.Substring(i, 2), NumberStyles.HexNumber);
        }
        return result;
    }
    // Variable portions of packet structure.
    var byte[] segment2 = GetBytesFrom(textbox1.Text);
    var byte[] segment4 = GetBytesFrom(textbox2.Text);
    var byte[] segment6 = GetBytesFrom(textbox3.Text);
    MemoryStream output = new MemoryStream();
    output.Write(new[] { 0x00, 0x38, 0x60, 0xdc, 0x00, 0x00 }, 0, 6);
    output.Write(segment2, 0, segment2.Length);
    output.Write(new[] { 0x00, 0x00, 0x00, 0x20 }, 0, 4);
    output.Write(segment4, 0, segment4.Length);
    output.Write(new[] { 0x00, 0x06 }, 0, 2);
    output.Write(segment6, 0, segment6.Length);
    
