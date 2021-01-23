    public class Wait : Form
    {
        BackgroundWorker _bgWorker = new BackgroundWorker(); 
        public delegate void toExecuteDele(object args); 
        public toExecuteDele ToExecute; 
        public Wait()
        {
            InitializeComponent(); 
            _bgWorker.DoWork += new DoWorkEventHandler( DoWork )
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler (WorkDone); 
        }  
        public void Execute(object args)
        {
             // Display Stuff (label, start a progress bar pulsing, maybe enable disable stuff 
                DispalyStuff(" Plate Wait"); 
             _bgWorker.RunBackgroundAsync(args); 
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
             if( ToExecute != null )
                ToExecute(e.Argument); 
              
        }  
        public void WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {  
            // Display an Error if there is an exception in the event args 
            Hide(); 
        }
    }
