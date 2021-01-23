    public class Wait
    {
        BackgroundWorker _bgWorker = new BackgroundWorker(); 
        public delegate void toExecuteDele(object args); 
        public toExecuteDele ToExecute; 
        public Wait()
        {
            _bgWorker.DoWork += new DoWorkEventHandler( DoWork )
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler (WorkDone); 
        }  
        public void Execute(object args)
        {
             _bgWorker.RunBackgroundAsync(args); 
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
             if( ToExecute != null )
                ToExecute(e.Argument); 
              
        }  
        public void WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {  
            Hide(); 
        }
    }
