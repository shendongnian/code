    // Variable portions of package structure.
    var byte[] segment2 = Encoding.ASCII.GetBytes(textbox1.Text);
    var byte[] segment4 = Encoding.ASCII.GetBytes(textbox2.Text);
    var byte[] segment6 = Encoding.ASCII.GetBytes(textbox3.Text);
    MemoryStream output = new MemoryStream();
    output.Write(new[] { 0x00, 0x38, 0x60, 0xdc, 0x00, 0x00 }, 0, 6);
    output.Write(segment2, 0, segment2.Length);
    output.Write(new[] { 0x00, 0x00, 0x00, 0x20 }, 0, 4);
    output.Write(segment4, 0, segment4.Length);
    output.Write(new[] { 0x00, 0x06 }, 0, 2);
    output.Write(segment6, 0, segment6.Length);
    
