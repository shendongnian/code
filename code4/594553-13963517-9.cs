    byte[] result;
    using (var ms = new MemoryStream()) {   // Expandable
        var bw = new BinaryWriter(ms);
        UInt32 len = 0x1337;
        bw.Write(len);
        // ...
        result = ms.GetBuffer();   // Get the underlying byte array you've created.
    }
