    public static void AddEventWatch(EventFilter filter)
    {
        SDL_EventFilter myFilter = (IntPtr data, ref SDL_Event e) => 
        {
            filter(new Event(ref e));
            return 0;    
        };
        
        GCHandle gch = GCHandle.Alloc(myFilter);
        try
        {
            var filterPointer = Marshal.GetFunctionPointerForDelegate(myFilter);
            SDL_AddEventWatch(filterPointer, IntPtr.Zero);
        }
        finally
        {
            gch.Free();
        }
    }
