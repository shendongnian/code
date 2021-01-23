        private readonly Queue<QueueItem<int>> _workerQueue = new Queue<QueueItem<int>>();
        private int _workerId = 1;
        [Test]
        public void BackgroundTest()
        {
            QueuedBackgroundWorker.QueueWorkItem(
                this._workerQueue, 
                this._workerId++,
                args =>  // DoWork
                    {
                        var currentTaskId = args.Argument;
                        var now = DateTime.Now.ToLongTimeString();
                        var message = string.Format("DoWork thread started at '{0}': Task Number={1}", now, currentTaskId);
                        return new { WorkerId = currentTaskId, Message = message };
                    },
                args =>  // RunWorkerCompleted
                    {
                        var currentWorkerId = args.Result.WorkerId;
                        var msg = args.Result.Message;
                        var now  = DateTime.Now.ToShortTimeString();
                        var completeMessage = string.Format(
                            "RunWorkerCompleted completed at '{0}'; for Task Number={1}, DoWork Message={2}",
                            now,
                            currentWorkerId,
                            msg);
                    }
                );
        }
