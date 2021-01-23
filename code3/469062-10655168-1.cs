    uint bytesRead;
    byte[] buffer = new byte[4];
    IntPtr baseAddress = P[0].MainModule.BaseAddress;
    for (int i = 0; i < _Length; i++)
    {
        IntPtr nextAddress = IntPtr.Add(baseAddress, i);
        if (ReadProcessMemory(
                P[0].Handle,
                nextAddress,
                buffer,
                buffer.Length,
                out bytesRead))
        {
            if (bytesRead == buffer.Length
             && BitConverter.ToInt32(buffer, 0) == Value)
            {
                tmp.Add(nextAddress);
            }
            else if (bytesRead != buffer.Length)
            {
                throw new InvalidOperationException(String.Format(
                    @"Read {0} bytes (expecting {1}) at {2:X}",
                    bytesRead,
                    buffer.Length,
                    nextAddress.ToInt64()));
            }
        }
        else
        {
            throw new InvalidOperationException(String.Format(
                @"Could not read {0} bytes at {1:X}",
                buffer.Length,
                nextAddress.ToInt64()));
        }
    }
    
    return tmp;
