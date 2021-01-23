    static byte[] CompressData(byte[] input, int size)
    {
        // The output buffer.
        IntPtr output = IntPtr.Zero;
    
        // Wrap in a try/finally, to make sure unmanaged array
        // is cleaned up.
        try
        {
            // Length.
            uint length = 0;
    
            // Make the call.
            CompressData(input, size, ref output, ref length);
    
            // Allocate the bytes.
            var bytes = new byte[(int) length)];
    
            // Copy.
            Marshal.Copy(output, bytes, 0, bytes.Length);
    
            // Return the byte array.
            return bytes;
        }
        finally
        {
            // If the pointer is not zero, free.
            if (output != IntPtr.Zero) Marshal.FreeCoTaskMem(output);
        }
    }
