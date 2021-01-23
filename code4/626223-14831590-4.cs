    Monitor.Enter(obj);
    // <=== Eeeek!
    try {
        // statements
    }
    finally {
        Monitor.Exit(obj);
    }
