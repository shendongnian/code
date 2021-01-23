    private static void UnderTest() {
      // Timer is a local varibale; it's callback is local as well
      System.Threading.Timer timer = new System.Threading.Timer(
        (s) => { MessageBox.Show("Timer!"); }, 
         null, 
         1000, 
         1000);
    }
...
    // Let's perform Garbage Colelction manually: 
    // we don't want any surprises 
    // (e.g. system starting collection in the middle of UnderTest() execution)
    GC.Collect(2, GCCollectionMode.Forced);
    UnderTest();
    // To delay garbage collection
    // Thread.Sleep(1500);
    // To perform Garbage Collection
    // GC.Collect(2, GCCollectionMode.Forced);
