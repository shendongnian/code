    bool IsFinal = true;
    int OpCode = 1;
    int? Mask = null;
    byte[] payload = Encoding.UTF8.GetBytes(Msg);
    int PayloadLength = payload.Length;
    byte[] buffer = new byte[64]; // for working out the header
    int offset = 0;
    buffer[offset++] = (byte)((IsFinal ? 128 : 0) | ((int)OpCode & 15));
    if (PayloadLength > ushort.MaxValue)
    { // write as a 64-bit length
        buffer[offset++] = (byte)((Mask.HasValue ? 128 : 0) | 127);
        buffer[offset++] = 0;
        buffer[offset++] = 0;
        buffer[offset++] = 0;
        buffer[offset++] = 0;
        buffer[offset++] = (byte)(PayloadLength >> 24);
        buffer[offset++] = (byte)(PayloadLength >> 16);
        buffer[offset++] = (byte)(PayloadLength >> 8);
        buffer[offset++] = (byte)(PayloadLength);
    }
    else if (PayloadLength > 125)
    { // write as a 16-bit length
        buffer[offset++] = (byte)((Mask.HasValue ? 128 : 0) | 126);
        buffer[offset++] = (byte)(PayloadLength >> 8);
        buffer[offset++] = (byte)(PayloadLength);
    }
    else
    { // write in the header
        buffer[offset++] = (byte)((Mask.HasValue ? 128 : 0) | PayloadLength);
    }
    if (Mask.HasValue)
    {
        int mask = Mask.Value;
        buffer[offset++] = (byte)(mask >> 24);
        buffer[offset++] = (byte)(mask >> 16);
        buffer[offset++] = (byte)(mask >> 8);
        buffer[offset++] = (byte)(mask);
    }
    // you might want to manually combine these into 1 packet
    client.Send(buffer, 0, offset, SocketFlags.None);
    client.Send(payload, 0, payload.Length, SocketFlags.None);
