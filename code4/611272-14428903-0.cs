    public virtual byte[] Get(byte[] bytes)
        {
            long oldpos = Position;
            bytes = reader.ReadBytes(bytes.Length);
            Position = oldpos;
            return bytes;
        }
