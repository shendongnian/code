    static void TakeConnection() {
         if(!someSemaphore.TakeOne(3000)) {
             throw new TimeoutException("Unable to reserve connection");
         }
    }
    static void ReleaseConnection() {
         someSemaphore.Release();
    }
    ...
    TakeConnection();
    try {
        using(var conn = GetConnection()) {
            ...
        }
    } finally {
        ReleaseConnection();
    }
