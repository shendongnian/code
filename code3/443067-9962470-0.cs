    using Marshal = System.Runtime.InteropServices.Marshal;
    private void releaseObject(ref object obj) // note ref!
    {
        // Do not catch an exception from this.
        // You may want to remove these guards depending on
        // what you think the semantics should be.
        if (obj != null && Marshal.IsComObject(obj)) {
            Marshal.ReleaseComObject(obj);
        }
        // Since passed "by ref" this assingment will be useful
        // (It was not useful in the original, and neither was the
        //  GC.Collect.)
        obj = null;
    }
