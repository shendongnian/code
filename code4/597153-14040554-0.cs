    if (Monitor.TryEnter(desiredOrdersBuy))
    {
        try
        {
            RecalculateOrdersInternal();
        }
        finally
        {
            Monitor.Exit(desiredOrdersBuy);
        }
    }
