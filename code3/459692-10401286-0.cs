    static BackgroundWorker[] d=new BackgroundWorker[MyListOfUrls.Length];
      string html=new string[MyListOfUrls.Length]
        
      static void Main(string[] args)
      {
        for (int i = 0; i < MyListOfUrls.Length; i++)
        {
             d[i]=new BackgroundWorker{WorkerReportsProgress=true};
             d[i].DoWork += new DoWorkEventHandler(worker2_DoWork);
             d[i].ProgressChanged += new ProgressChangedEventHandler(Program_ProgressChanged);
             d[i].RunWorkerAsync(i);
             d[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
             Thread.Sleep(1000);
        }
      }  
      
      static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
          Console.WriteLine("End");
      }
        
      static void Program_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
          Console.WriteLine(e.ProgressPercentage.ToString());
      }
        
      static void worker2_DoWork(object sender, DoWorkEventArgs e)
      {
          var worker = (BackgroundWorker)sender;
          worker.ReportProgress((int)e.Argument);
        
          HttpDownloader httpDownload = new HttpDownloader(link);
          html[(int)e.Argument] = httpDownload.GetPage();
        
          Thread.Sleep(500);
      }
