    public override void Write(byte[] buffer, int offset, int count)
    {
        // EnsureCapacity
        byte[] dst = new byte[value];
        Buffer.InternalBlockCopy(_buffer, 0, dst, 0, _length);
        _buffer = dst;
        // Copy
        Buffer.InternalBlockCopy(buffer, offset, _buffer, _position, count);
    }
