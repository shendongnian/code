    PrivateFontCollection privateFontCollection = new PrivateFontCollection();
    
    var memory = IntPtr.Zero;
    try
    {
        memory = Marshal.AllocCoTaskMem(value.Length);
    
        Marshal.Copy(value, 0, memory, value.Length);
        privateFontCollection .AddMemoryFont(memory, value.Length);
    }
    finally
    {
        Marshal.FreeCoTaskMem(memory);
    }
    
    return new Font(privateFontCollection.Families[0], fontSize);
