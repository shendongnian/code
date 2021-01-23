    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form3 : Form
        {
            private BackgroundWorker _worker;
            BusinessClass _biz = new BusinessClass();
            public Form3()
            {
                InitializeComponent();
                InitWorker();
            }
    
            private void InitWorker()
            {
                if (_worker != null)
                {
                    _worker.Dispose();
                }
    
                _worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                _worker.DoWork += DoWork;
                _worker.RunWorkerCompleted += RunWorkerCompleted;
                _worker.ProgressChanged += ProgressChanged;
                _worker.RunWorkerAsync();
            }
    
    
            void DoWork(object sender, DoWorkEventArgs e)
            {
                int highestPercentageReached = 0;
                if (_worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    double i = 0.0d;
                    int junk = 0;
                    for (i = 0; i <= 199990000; i++)
                    {
                        int result = _biz.MyFunction(junk);
                        junk++;
    
                        // Report progress as a percentage of the total task.
                        var percentComplete = (int)(i / 199990000 * 100);
                        if (percentComplete > highestPercentageReached)
                        {
                            highestPercentageReached = percentComplete;
                            // note I can pass the business class result also and display the same in the LABEL  
                            _worker.ReportProgress(percentComplete, result);
                            _worker.CancelAsync();
                        }
                    }
    
                }
            }
    
            void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                {
                    // Display some message to the user that task has been
                    // cancelled
                }
                else if (e.Error != null)
                {
                    // Do something with the error
                }
            }
    
            void ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                label1.Text =  string.Format("Result {0}: Percent {1}",e.UserState, e.ProgressPercentage);
            }
        }
        public class BusinessClass
        {
            public int MyFunction(int input)
            {
                return input+10;
            }
        }
    }
