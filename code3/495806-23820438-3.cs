            public void CreateQueue()
        {
            if (!MessageQueue.Exists(_logQueuePath))
            {
                MessageQueue.Create(_logQueuePath);
            }
        }
