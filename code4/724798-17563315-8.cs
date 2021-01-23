    internal static SafeUnmanagedMemoryHandle StructToPtr(object obj)
    {
        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
        Marshal.StructureToPtr(obj, ptr, false);
        return new SafeUnmanagedMemoryHandle(ptr, true);
    }
    
    [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy")]
    internal static extern int RenderCopy(IntPtr renderer, IntPtr texture, SafeUnmanagedMemoryHandle srcrect, SafeUnmanagedMemoryHandle dstrect);
