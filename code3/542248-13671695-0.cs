    private volatile bool _executing;
    private void TimerElapsed(object state)
    {
        if (_executing)
            return;
        _executing = true;
        try
        {
            // do the real work here
        }
        catch (Exception e)
        {
            // handle your error
        }
        finally
        {
            _executing = false;
        }
    }
