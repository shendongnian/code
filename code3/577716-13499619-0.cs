    bool TryProcessWithRetries(int retries) {
        for (int attempt = 0; attempt < retries; attempt++) {
            if (TryProcess()) {
                return true;
            }
            Thread.Sleep(200);
        }
        // Throw an exception here instead?
        return false;
    }
    bool TryProcess() {
        foreach (var connection in _connections) {
            if (TryProcess(connection)) {
                return true;
            }
        }
        return false;
    }
    bool TryProcess(CalcEngineConnection connection) {
        if (!Monitor.TryEnter(connection)) {
            return false;
        }
        try {
            var calcEnginePool = _pendingPool.Dequeue();
            connection.RunCalc(calcEnginePool);
        } finally {
            Monitor.Exit(connection);
        }
        return true;
    }
