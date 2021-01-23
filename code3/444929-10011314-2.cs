    // In PoolDemo
    static AtomicLong FastestMemory = new AtomicLong(2000000);
    static AtomicLong SlowestMemory = new AtomicLong(0);
    . . . . .
    // In Task
    long temp = FastestMemory.get();       
    if (Duration < temp) {
        FastestMemory.compareAndSet (temp, Duration);
    }
    temp = SlowestMemory.get();
    if (Duration > temp) {
        SlowestMemory.compareAndSet (temp, Duration);
    }
