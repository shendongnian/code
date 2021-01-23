    X x = new X();
    x.M((int)10);               // "M(int)"
    x.M((long)10);              // "M(long)"
    x.M((dynamic)10);           // "M(int)"
    x.M((dynamic)String.Empty); // RuntimeBinderException
