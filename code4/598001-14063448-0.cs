    public Task ExecuteConsecutively(IEnumerable<Action> actions) {
        Task previousTask = null;
        foreach (var action in actions) {
            if (previousTask == null) {
                previousTask = Task.Factory.StartNew(action);
            } else {
                previousTask = previousTask.ContinueWith(_ => action());
            }
        }
        return previousTask;
    }
