    public partial class Form1 : Form
    {
        //--------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            
            //Initialize backgroundworker
            Shown += new EventHandler(Form1_Shown);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged +=
            new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            
            //counter
            YourObject.Counter = 100;
        }
        
        //--------------------------------------------------------------------------
        void btnClick_Clicked(object sender, EventArgs e)
        {
            //Trigger the background process
            backgroundWorker1.RunWorkerAsync();
        }
        
        //--------------------------------------------------------------------------
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Your freakishly long process,
            //which needs to be run in the background
            
            //to make it simple, I'll just do a for loop
            for (int i  = 0; i < 100; i++)
            {
                //The counter will keep track of your process
                //In your case, it might not be a for loop
                //So you will have to decide how to keep track of this counter
                //My suggestion is to decrease/increase this counter
                //right after importants action of your process
                backgroundWorker1.ReportProgress(YourObject.Counter--);
            }
        }
        
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //The counter is updated and displayed with a progress bar 
            YourObject.Counter = e.ProgressPercentage;
        }
    }
