    public class AsyncClass
    {
        public delegate void WorkFinishedDelegate();
        public event WorkFinishedDelegate WorkFinishedEvent;
        public void StartJob()
        {
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(DoSomeJob);
            System.Threading.Thread th = new System.Threading.Thread(ts);
            //this will stast async thread...
            th.Start();
        }
        void DoSomeJob()
        { 
            //TODO: do your job
            //nofity you have completed...
            if (WorkFinishedEvent!= null)
            {
                WorkFinishedEvent();
            }
        }
    }
