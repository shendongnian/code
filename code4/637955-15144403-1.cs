    public class Processing
    {        
        public void run(IProgress<string> progress)
        {               
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);//placeholder for real work
                progress.Report("i");
            }                    
        }
    }
