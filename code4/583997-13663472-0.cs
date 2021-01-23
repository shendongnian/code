    public class MyAsyncClass
    {
        public delegate void NotifyComplete(DataSet data);
        public event NotifyComplete NotifyCompleteEvent;
        //Starts async thread...
        public void Start()
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(DoSomeJob));
            t.Start();
        }
        void DoSomeJob()
        {
            //just wait 5 sec for nothing special...
            System.Threading.Thread.Sleep(5000);
            if (NotifyCompleteEvent != null)
            {
                //TODO: fill your data...
                DataSet ds = new System.Data.DataSet();
                NotifyCompleteEvent(ds);
            }
        }
    }
