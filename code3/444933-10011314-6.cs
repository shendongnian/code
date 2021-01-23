    // In PoolDemo
    static AtomicLong FastestMemory = new AtomicLong(2000000);
    static AtomicLong SlowestMemory = new AtomicLong(0);
    . . . . .
    // In Task
    long temp = FastestMemory.get();       
    while (Duration < temp) {
        if (!FastestMemory.compareAndSet (temp, Duration)) {
            temp = FastestMemory.get();       
        }
    }
    temp = SlowestMemory.get();
    while (Duration > temp) {
        if (!SlowestMemory.compareAndSet (temp, Duration)) {
            temp = SlowestMemory.get();
        }
    }
