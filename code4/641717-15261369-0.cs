        // If action already in progress, add new
        //  action to queue and return.
        // If no action in progress, begin processing
        //  the new action and continue processing
        //  actions added to the queue in the meantime.
        void SequenceAction(Action action) {
           lock (_SequenceActionQueueLock) {
              _SequenceActionQueue.Enqueue(action);
              if (_SequenceActionQueue.Count > 1) {
                 return;
              }
           }
           // Would have returned if queue was not empty
           //  when queue was locked and item was enqueued.
           for (;;) {
              action();
              lock (_SequenceActionQueueLock) {
                 _SequenceActionQueue.Dequeue();
                 if (_SequenceActionQueue.Count == 0) {
                    return;
                 }
                 action = _SequenceActionQueue.Peek();
              }
           }
        }
        
