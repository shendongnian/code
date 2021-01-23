    public MemoryStream()
    {    
        _buffer = new byte[0];   
        _writable = true;
        _exposable = true;
    }
    public override void Write(byte[] buffer, int offset, int count)
    {
        // EnsureCapacity
        byte[] dst = new byte[_position + count];
        Buffer.InternalBlockCopy(_buffer, 0, dst, 0, _length);
        _buffer = dst;
        // Copy
        Buffer.InternalBlockCopy(buffer, offset, _buffer, _position, count);
    }
