    public partial class Service1 : ServiceBase
    {
        private System.ComponentModel.BackgroundWorker bwMyWorker;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            bwMyWorker = new BackgroundWorker();            
            bwMyWorker.DoWork += delegate(object sender, DoWorkEventArgs workArgs)
            {
                //Endless loop
                for (; ; )
                {
                    //Your work... E.g. add()
                    System.Threading.Thread.Sleep(new TimeSpan(0, 5, 0)); //Pause for 5 min
                }
            };
            bwMyWorker.RunWorkerAsync();
        }
