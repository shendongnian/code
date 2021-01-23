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
       }
       void Form1_Shown(object sender, EventArgs e)
       {
           backgroundWorker1.RunWorkerAsync();
       }
       void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
       {
           foreach (string file in finalFiles)
           {
               //Your processes
               backgroundWorker1.ReportProgress(i);
           }
       }  
       void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
            progressBar1.Value = e.ProgressPercentage;
       }
    }
