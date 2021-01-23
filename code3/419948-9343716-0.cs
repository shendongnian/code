    unsafe void bufferOverflow(string s)
    {
        char* ptr = stackalloc char[10];
        foreach (var c in s)
        {
            if (c == '\0') break;
            *ptr++ = c; // Bufferoverflow if s.Length > 10
        }
    }
