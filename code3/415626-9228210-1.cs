    Monitor.Enter(obj);
    try {
        var result = value;
    }
    finally {
        Monitor.Exit(obj);
    }
    return result;
