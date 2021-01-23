    using System;
    using System.Text;
    using System.Diagnostics;
    
    public class WeakReferenceTests
    {
        public void TestWeakReferenceIsDisposed()
        {
            WeakReference weakRef = new WeakReference(new StringBuilder("Hello"));
    
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            GC.Collect();
    
            var retrievedSb = weakRef.Target as StringBuilder;
            Debug.Assert(retrievedSb == null);
        }
    }
