    // Forces a collection of all generations from 0 through Generation.
    //
    public static void Collect(int generation) {
        Collect(generation, GCCollectionMode.Default);
        }
  
    // Garbage Collect all generations.
    //
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static void Collect() {
        //-1 says to GC all generations.
        _Collect(-1, (int)GCCollectionMode.Default);
    }
 
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static void Collect(int generation, GCCollectionMode mode)
    {
        if (generation<0)
        {
            throw new ArgumentOutOfRangeException("generation", Environment.GetResourceString("ArgumentOutOfRange_GenericPositive"));
        }
        if ((mode < GCCollectionMode.Default) || (mode > GCCollectionMode.Optimized))
        {
            throw new ArgumentOutOfRangeException(Environment.GetResourceString("ArgumentOutOfRange_Enum"));
        }
        Contract.EndContractBlock();
        _Collect(generation, (int)mode);
    }
