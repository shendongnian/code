    unsafe class C
    {
        static int x;  // Assumed to be initialized to zero
        static int *p; // Assumed to be initialized to null
        static void M()
        {
            int* t = &C.x;
            *t = 1;
            C.p = t;
        }
        ...
