        public void CheckPauseStatusAndExecuteIfTrue(Action action)
        {
            if (!this.isPaused)
            {
                action();
            }
        }
...
        [OperationContract]
        public void DoWork()
        {
            this.CheckPauseStatusAndExecuteIfTrue(() =>
            {
                //// write your method behavior
            });
        }
