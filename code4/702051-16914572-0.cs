    public class Job
    {
        private bool state;
        public bool State
        {
           get { return this.state; }
           set
           {
              this.state = value;
              processFile();
           } 
    
        private void processFile()
        {
           // do work
        }
    }
