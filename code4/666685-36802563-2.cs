    public class CustomBackgroundWorker : BackgroundWorker
    {
        public object Argument { get; private set; }
    
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            Argument = e.Argument;
            base.OnDoWork(e);
        }
    }
