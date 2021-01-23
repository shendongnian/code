    [MethodImpl(MethodImplOptions.InternalCall)]
    private static void nativeCollectGeneration(int generation, int mode); 
    public static void Collect()
    {
      GC.nativeCollectGeneration(-1, 0);
    }
    
    public static void Collect(int generation)
    {
      GC.Collect(generation, GCCollectionMode.Default);
    }
