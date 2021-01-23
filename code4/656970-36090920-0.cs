    while (true) {
      Monitor.Enter(mutex);
      if (queue.Count == 0) {
        Monitor.Wait(mutex);
      }
      queue.Dequeue();
      Monitor.Exit(mutex);
    }
    while (true) {
      Monitor.Enter(mutex);
      if (queue.Count == 0) {
        Monitor.Wait(mutex);
      }
      queue.Dequeue();
      Monitor.Exit(mutex);
    }
    while (true) {
      Monitor.Enter(mutex);
      queue.Enqueue(42);
      Monitor.PulseAll(mutex);
      Monitor.Exit(mutex);
    }
