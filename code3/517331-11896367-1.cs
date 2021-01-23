        ///    <para>
        ///    For base classes, you should never override the Finalier (~Class in C#) 
        ///    or the Dispose method that takes no arguments, rather you should 
        ///    always override the Dispose method that takes a bool.
        ///    </para> 
        ///    <code>
        ///    protected override void Dispose(bool disposing) {
        ///        if (disposing) {
        ///            if (myobject != null) { 
        ///                myobject.Dispose();
        ///                myobject = null; 
        ///            } 
        ///        }
        ///        if (myhandle != IntPtr.Zero) { 
        ///            NativeMethods.Release(myhandle);
        ///            myhandle = IntPtr.Zero;
        ///        }
        ///        base.Dispose(disposing); 
        ///    }
