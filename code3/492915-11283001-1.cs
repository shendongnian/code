    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using FileWatchDog.Properties;
    using System.Text.RegularExpressions;
    
    namespace FileWatchDog
    {
    public partial class Form1 : Form
    {
        BackgroundWorker backgroundWorker1;
        public Form1()
        {
            InitializeComponent();
    
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
    
        private void FileWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            ListViewItem newFile = new ListViewItem(new string[] { e.FullPath.ToString(), e.ChangeType.ToString() }, -1);
            newFile.Tag = e.FullPath.ToString();
            FileList.Items.Add(newFile);
        }
    
        private void CopyButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerAsync();
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int TotalFiles = FileList.CheckedItems.Count;;
            int CurrentFile = 1;
            foreach (ListViewItem CheckedFile in FileList.CheckedItems)
            {
                backgroundWorker1.ReportProgress((CurrentFile / TotalFiles) * 100);
                string FileBuilder = Settings.Default.Destination + Path.GetFileName(CheckedFile.Tag.ToString());
                if (File.Exists(FileBuilder) == false)
                {
                    File.Copy(CheckedFile.Tag.ToString(), FileBuilder);
                }
                CurrentFile++;
            }
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CopyProgressBar.Value = e.ProgressPercentage;
    
        }
      }
    }
