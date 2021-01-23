    const int N = 5;
    T[] ar = new T[N];               // Temporary array of N items.
    int i=0;
    foreach(var item in q) {         // Just one iterator.
        ar[i++] = item;              // Store a reference to this item.
        if (i == N) {                // When we have N items,
            ar.Dump();               // dump them,
            i = 0;                   // and reset the array index.
        }
    }
    // Dump the remaining items
    if (i > 0) {
        ar.Take(i).Dump();
    }
