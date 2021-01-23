    public Task ExecuteConsecutivelyAsync(IEnumerable<Action> actions) {
        return Task.Factory.StartNew(delegate {
            foreach (var action in actions) {
                action();
            }
        });
    }
