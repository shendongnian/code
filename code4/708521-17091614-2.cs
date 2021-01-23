    GCHandle handle;
    IntPtr ptr;
    byte[] bytes;
    bytes = new byte[1];
    handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    ptr = handle.AddrOfPinnedObject();
    ptr.ToInt32().Dump(); // Prints 239580124
    handle.Free();
    
    unsafe {
        fixed(void* pBytes = bytes)
        {
            ((int)pBytes).Dump(); //prints 239580124
        }
    }
    bytes = new byte[0];
    handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    ptr = handle.AddrOfPinnedObject();
    ptr.ToInt32().Dump(); // Prints 239609660
    handle.Free();
    
    unsafe {
        fixed(void* pBytes = bytes)
        {
            ((int)pBytes).Dump(); //prints 0
        }
    }
