    struct S
    {
        public int f;
    }
    delegate void DoDelegate(ref S s);
        public static void M()
        {
            var i = 5;
            var s = new S();
            var del = new DoDelegate(delegate(ref S st) { st.f = i; });
            del.Invoke(ref s);
        }
