    class C
    {
        public int handle;
        ...
        ~C() { InteropLibrary.DestroyHandle(handle); }
    }
    void M()
    {
        C c = GetSomeObjectUsefulInUnmanagedCode();
        D d = InteropLibrary.UnmanagedMethodThatUsesHandle(c);
        // COMMENT
        d.DoSomethingWithStoredHandle();
    }
