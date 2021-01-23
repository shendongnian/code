        private Queue<myCopyTask> queue;
        private Timer retryTimeout;
        public Program()
        {
            retryTimeout = new Timer(QueueProcess, null, Timeout.Infinite, Timeout.Infinite);
        }
        private void FileSystemMonitorEventhandler()
        {
            //New tasks are provided by the file system monitor.
            myCopyTask newTask = new myCopyTask();
            newTask.sourcePath = "...";
            newTask.destinationPath = "...";
            //Keep in mind that queue is touched from different threads.
            lock (queue)
            {
                queue.Enqueue(newTask);
            }
            //Keep in mind that Timer is touched from different threads.
            lock (retryTimeout)
            {
                retryTimeout.Change(1000, Timeout.Infinite);
            }
        }
        //Start this routine only via Timer.
        private void QueueProcess(object iTimeoutState)
        {
            myCopyTask task = null;
            do
            {
                //Keep in mind that queue is touched from different threads.
                lock (queue)
                {
                    if (queue.Count > 0)
                    {
                        task = queue.Dequeue();
                    }
                }
                if (task != null)
                {
                    CopyTaskProcess(task);
                }
            } while (task != null);
        }
        private async void CopyTaskProcess(myCopyTask task)
        {
            FileStream sourceStream = null;
            FileStream destStream = null;
            try
            {
                sourceStream = File.OpenRead(task.sourcePath);
                destStream = File.OpenWrite(task.destinationPath);
                await sourceStream.CopyToAsync(destStream);
            }
            catch (Exception copyException)
            {
                task.retryCount++;
                //Keep in mind that queue is touched from different threads.
                lock (queue)
                {
                    queue.Enqueue(task);
                }
                //Keep in mind that Timer is touched from different threads.
                lock (retryTimeout)
                {
                    retryTimeout.Change(1000, Timeout.Infinite);
                }
            }
            finally
            {
                if (sourceStream != null)
                {
                    sourceStream.Close();
                }
                if (destStream != null)
                {
                    destStream.Close();
                }
            }
        }
    }
    internal class myCopyTask
    {
        public string sourcePath;
        public string destinationPath;
        public long retryCount;
    }
