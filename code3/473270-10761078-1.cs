    public class Worker_Class
    {
        //Various Setup stuff up here
    
        public class IterationEventArgs : EventArgs
        {
            public string iterationNumber { get; set; }
        }
    
        public event EventHandler<IterationEventArgs> IterationComplete;
    
        public void LengthyTask()
        {
            int iteration = 0;
    
            while (iteration < 10)
            {
                DateTime saveNOW = DateTime.Now;        //lets say I report this back to the the GUI to write in that ShowInfo box
                Thread.Sleep(10000);                    //To waste time and make this lengthy
    
                //Your code here to facilitate sending saveNOW back to the the Main_Class and display it on the ShowInfo textbox.
    
                if (IterationComplete != null)
                {
                    IterationEventArgs args = new IterationEventArgs();
                    args.iterationNumber = iteration.ToString();
                    IterationComplete(this, args);
                }
    
                iteration++;
            }
        }
    }
