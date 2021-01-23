    int count = 0;
    event EventHandler MyThing.Change
    {
        add
        {
            lock (Change)
            {
                if (count == 0)
                {
                    StartWatching();
                }
                count++;
                Change += value;
            }
        }
        remove
        {
            lock (Change)
            {
                count--;
                if (count == 0)
                {
                    StopWatching();
                }
                Change -= value;
            }
        }
    }
