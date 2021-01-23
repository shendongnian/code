    using System;
    class P
    {
        static void M<R>(params Func<R>[] p) {}
        static void N(int i, string s, decimal m)
        {
            M(()=>i, ()=>s); // fails
            M(()=>i, ()=>s.Length); // succeeds
            M(()=>i, ()=>m); // succeeds
        }
    }
