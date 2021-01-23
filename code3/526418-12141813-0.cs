        private object syncRoot = new object();
        private Task latestTask;
        public void EnqueueAction(System.Action action)
        {
            lock (syncRoot)
            {
                if (latestTask == null)
                {
                    downloadedDialogs = 0;
                    latestTask = Task.Factory.StartNew(action);
                }
                else if(latestTask.IsCompleted && !RefreshingDialogs)
                {
                    RefreshingDialogs = true;
                    downloadedDialogs = 0;
                    latestTask = Task.Factory.StartNew(action);
                }
            }
        }
        private void Message_Refresh_Click(object sender, EventArgs e)
        {
            Action ac = new Action(LoadDialogs2);
            EnqueueAction(ac);
        }
