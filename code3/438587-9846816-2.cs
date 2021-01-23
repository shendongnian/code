        private List<string> listToRemove = new List<string>();
        public Form1()
        {
            InitializeComponent();
            listBoxFiles.Items.Add("1.avi");
            listBoxFiles.Items.Add("2.avi");
            listBoxFiles.Items.Add("3.wrong");
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var file in listToRemove)
            {
                // Imitate hard conversion
                Thread.Sleep(5000);
                var newFileName = Path.ChangeExtension(file, "avi");
                // save NEW file to file system here...
                
                // delete old file from file system
                File.Delete(file);
            }
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var file in listToRemove)
            {
                var newFileName = Path.ChangeExtension(file, "avi");
                listBoxFiles.Items.Add(newFileName);
            }
            listBoxFiles.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listToRemove = new List<string>();
            for (int i = 0; i < listBoxFiles.Items.Count; i++)
            {
                string path = (string)listBoxFiles.Items[i];
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Extension != ".avi")
                {
                    listToRemove.Add(path);
                    listBoxFiles.Items.Remove(path);
                }
            }
            listBoxFiles.Enabled = false;
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync(listToRemove);
            }
        }
    }
