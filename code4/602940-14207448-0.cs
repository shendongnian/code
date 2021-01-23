    var msg = new MessageFormat();
    var arr = new byte[msg.Header.Length + 1 + 1 + msg.Authentication.Length + msg.Flag.Length + msg.Data.Length + msg.Trailer.Length];
    using (var stream = new MemoryStream(arr, 0, arr.Length, true))
    {
        stream.Write(msg.Header, 0, msg.Header.Length);
        stream.WriteByte(msg.Fragmentation);
        stream.WriteByte(msg.Encryption);
        stream.Write(msg.Authentication, 0, msg.Authentication.Length);
        stream.Write(msg.Flag, 0, msg.Flag.Length);
        stream.Write(msg.Data, 0, msg.Data.Length);
        stream.Write(msg.Trailer, 0, msg.Trailer.Length);
    }
