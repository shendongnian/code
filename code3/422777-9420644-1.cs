    int a = 0;
    long b = 0;
    Trace.Assert(a.Equals((int)b));     // True   32bits compared to 32bits
    Trace.Assert(a.Equals((long)b));    // False  32bits compared to 64bits (widening)
    Trace.Assert(b.Equals((long)a));    // True   64bits compared to 64bits
    Trace.Assert(b.Equals((int)a));     // True   64bits compared to 32bits (narrowing)
