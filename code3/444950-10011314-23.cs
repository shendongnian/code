    // In PoolDemo
    static Integer _monitor = new Integer(1);
    static volatile long FastestMemory = 2000000;
    static volatile long SlowestMemory = 0;
    
    ...
    // In Task
    synchronized (PoolDemo._monitor) {
        if (Duration < FastestMemory) {
            FastestMemory = Duration;
        }
        if (Duration > SlowestMemory) {
            SlowestMemory = Duration;
        }
    }
