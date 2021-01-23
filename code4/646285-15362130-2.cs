      private delegate void ThreadDone(MyObject obj);
      private delegate void TaskDone();
      public void DoWork(object sender)
       {
            MyObject obj = (MyObject)sender;
            
            this.Invoke(new ThreadDone(ReportProgress), result);
            Interlocked.Decrement(ref workItems);
            if (workItems == 0)
            {
                this.Invoke(new TaskDone(WorkComplete));
            }
        }
