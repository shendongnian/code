    for (int i = 0; i < msgCount; i++)
    {
        int copyOfI = i;
        if (i < msgCount)
        {
            _tasks[i] = Task.Factory.StartNew(() =>
            {
                lock (_locker)
                {
                    PushMessage(copyOfI);
                }
            });
        }
    }
