    public partial class Form1 : Form
    {
       public Form1()
       {
           InitializeComponent();
           Shown += new EventHandler(Form1_Shown); 
           backgroundWorker1.WorkerReportsProgress = true;
           backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
           backgroundWorker1.ProgressChanged += 
           new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
           pbUpload.Value = 70;
       }
       void Form1_Shown(object sender, EventArgs e)
       {
           backgroundWorker1.RunWorkerAsync();
       }
       int val = 0;
       void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
       {
           val = (100 - pbUpload.Value) / finalFiles.Length;
           foreach (string file in finalFiles)
           {
               //Your processes
               pbUpload.Value += val;
               backgroundWorker1.ReportProgress(pbUpload.Value);
           }
       }  
       void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
            progressBar1.Value = e.ProgressPercentage;
       }
    }
