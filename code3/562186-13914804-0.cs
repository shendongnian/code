    public IEnumerator<Action> GetEnumerator()
    {
        lock(sync)
        {
            return _actions.ToList().GetEnumerator();
        }
    }
