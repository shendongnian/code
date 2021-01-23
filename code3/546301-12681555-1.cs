    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using Microsoft.Practices.Prism.Commands;
    
    namespace CopyFiles
    {
        public class CopyModel: INotifyPropertyChanged
        {
    
            private string source;
            private string destination;
            private bool copyInProgress;
            private int progress;
            private ObservableCollection<string> excludedDirectories;
    
            public CopyModel()
            {
                this.CopyCommand = new DelegateCommand(ExecuteCopy, CanCopy);
                this.excludedDirectories = new ObservableCollection<string>();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            
            public string Source
            {
                get { return source; }
                set
                {
                    source = value;
                    RaisePropertyChanged("Source");
                    CopyCommand.RaiseCanExecuteChanged();
                }
            }
    
            public string Destination
            {
                get { return destination; }
                set
                {
                    destination = value;
                    RaisePropertyChanged("Destination");
                    CopyCommand.RaiseCanExecuteChanged();
                }
            }
    
            public bool CopyInProgress
            {
                get { return copyInProgress; }
                set
                {
                    copyInProgress = value;
                    RaisePropertyChanged("CopyInProgress");
                    CopyCommand.RaiseCanExecuteChanged();
                }
            }
    
            public int Progress
            {
                get { return progress; }
                set
                {
                    progress = value;
                    RaisePropertyChanged("Progress");
                }
            }
    
            public ObservableCollection<string> ExcludedDirectories
            {
                get { return excludedDirectories; }
                set 
                { 
                    excludedDirectories = value;
                    RaisePropertyChanged("ExcludedDirectories");
                }
            }
    
    
            public DelegateCommand CopyCommand { get; set; }
    
            public bool CanCopy()
            {
                return (!string.IsNullOrEmpty(Source) &&
                        !string.IsNullOrEmpty(Destination) &&
                        !CopyInProgress);
            }
    
            public void ExecuteCopy()
            {
                BackgroundWorker copyWorker = new BackgroundWorker();
                copyWorker.DoWork +=new DoWorkEventHandler(copyWorker_DoWork);
                copyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(copyWorker_RunWorkerCompleted);
                copyWorker.ProgressChanged += new ProgressChangedEventHandler(copyWorker_ProgressChanged);
                copyWorker.WorkerReportsProgress = true;
                copyWorker.RunWorkerAsync();
            }
            
            private void RaisePropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if(handler != null) 
                {
                    var eventArgs = new PropertyChangedEventArgs(propertyName);
                    handler(this, eventArgs);
                }
            }
    
            private void copyWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                var worker = sender as BackgroundWorker;
                this.CopyInProgress = true;
                worker.ReportProgress(0);
    
                var directories = Directory.GetDirectories(source, "*", System.IO.SearchOption.AllDirectories);
                var files = Directory.GetFiles(source, "*.*", System.IO.SearchOption.AllDirectories);
                var total = directories.Length + files.Length;
                int complete = 0;
    
                foreach (string dir in directories)
                {
                    if (!ExcludedDirectories.Contains(dir))
                        Directory.CreateDirectory(destination + dir.Substring(source.Length));
                    complete++;
                    worker.ReportProgress(CalculateProgress(total, complete));
                }
    
                foreach (string file_name in files)
                {
                    if (!File.Exists(Path.Combine(destination + file_name.Substring(source.Length))))
                        File.Copy(file_name, destination + file_name.Substring(source.Length));
                    complete++;
                    worker.ReportProgress(CalculateProgress(total, complete));
                }
            }
    
            private static int CalculateProgress(int total, int complete)
            {
                // avoid divide by zero error
                if (total == 0) return 0;
                // calculate percentage complete
                var result = (double)complete / (double)total;
                var percentage = result * 100.0;
                // make sure result is within bounds and return as integer;
                return Math.Max(0,Math.Min(100,(int)percentage));
            }
    
            private void copyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                this.Progress = e.ProgressPercentage;
            }
    
            private void copyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                this.CopyInProgress = false;
            }
        }
    }
