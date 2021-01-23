    using System;
    using System.ServiceProcess;
    using System.Threading;
    using System.Timers;
    using System.IO;
 
    namespace MyNamespace
    {
        public partial class Service1:  ServiceBase
        {
            Thread syncThread = null;
            System.Timers.Timer timer1;
            string filePath = @"C:\myfile.txt";
 
            public Service1()
            {
               InitializeComponent();             
            }
 
            protected override void OnStart(string[] args)
            {
                timer1 = new System.Timers.Timer();
                timer1.Interval = 60000; // 1 min  -- adjust as necessary
                timer1.Enabled = true;
                timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
                timer1.Start();
            }
            protected override void OnStop()
            {
                syncThread.Abort();
                timer1.Stop();
            }
            protected void timer1_Elapsed(object sender, ElapsedEventArgs e)
            {
                syncThread = new Thread(new ThreadStart(doThread));
                syncThread.Start();
            }
            protected void doThread()
            {
                // whatever you put here, it will
                // run for each timer interval that elapses
                // in a separate thread, and each thread will
                // end when the processing in this function ends
                string fileContent = String.Empty;      
                if (File.Exists(filePath)
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    fileContent = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                } 
                if (fileContent != String.Empty)
                {
                   // File was present... process the content...
                   // Then I do this...
                   File.Delete();
                }
            } 
        }
    }
