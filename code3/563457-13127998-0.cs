    public class MyWorker//TODO give better name
    {
        public void DoWork(BackgroundWorker worker)//TODO give better name
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);//to mimic real work
                worker.ReportProgress(0, i.ToString());
            }
        }
    }
