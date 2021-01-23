    byte[] bytes = new byte[16];
    
    BitConverter.GetBytes(i1).CopyTo(bytes, 0);
    BitConverter.GetBytes(i2).CopyTo(bytes, 4);
    BitConverter.GetBytes(dt.Ticks).CopyTo(bytes, 8);
    
    Guid key = new Guid(bytes);
