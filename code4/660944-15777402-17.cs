    var messagePublisher = m_ServerClient.MessageQueue
      .GetConsumingEnumerable()
      .ToObservable(TaskPoolScheduler.Default)
      .Multicast(subject)
      // Here: connectable observables are a PITA...
      .RefCount();
