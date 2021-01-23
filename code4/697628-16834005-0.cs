    public IEnumerator<T> GetEnumerator()
    {
        TaskFactory<T> taskFactory = new TaskFactory<T>();
        Task<T> task = null;
        IEnumerator<T> enumerator = Source.GetEnumerator();
        T result = null;
        do
        {
            if (task != null)
            {
                result = task.Result;
                if (result != null)
                    yield return result;
                else
                    break;
            }
            task = taskFactory.StartNew(() =>
            {
                if (enumerator.MoveNext())
                    return enumerator.Current;
                else
                    return null;
            });
        }
        while (task != null);
    }
