    private int count;
    ...
    void MyForEachDelegate(string urlStr) {
        ...
        int pos = Interlocked.Increment(ref count);
        if ((pos-1) % 1000 == 0) {
            Console.WriteLine("Processing URL number {0}", pos);
        }
    }
