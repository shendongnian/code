    struct S
    {
        public int f;
    }
    delegate void DoDelegate(ref S s);
    public static void M()
    {
        var s = new S();
        DoDelegate delegate2 = (ref S st) => st.f = 5;
        DoDelegate delegate1 = delegate(ref S st) { st.f = 10; };
        delegate1.Invoke(ref s);
        delegate2.Invoke(ref s);
    }
