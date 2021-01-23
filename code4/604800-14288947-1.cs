    public ReportTable GetReportTable(ReportQuery query)
    {
      lock (_queue)
      {
        _queue.Enqueue(query);
        Monitor.Pulse(_queue);
      }
      lock (_queue)
      {
        var firstQueryInQueue = _queue.Peek();
        while (_inUse || firstQueryInQueue == null || firstQueryInQueue.GetHashCode() != query.GetHashCode())
        {
          Monitor.Wait(_queue);
        }
        _inUse = true;
        firstQueryInQueue = _queue.Dequeue();
        var table = firstQueryInQueue.GetNewReportTable();
        _inUse = false;
        Monitor.Pulse(_queue);
        return table;
      }
    }
