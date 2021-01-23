    public static Effects Create(byte[] effectsData)
    {
       GCHandle gch;
       try
       {
           gch = GCHandle.Alloc( effectsData, GCHandleType.Pinned );
           IntPtr pEffects = gch.AddrOfPinnedObject( );
           return (Effects)Marshal.PtrToStructure( pEffects, typeof(Effects) );
       }
       finally
       {
           if (gch.IsAllocated)
               gch.Free( );
       }
    }
