    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Management.Automation;
    using System.Collections.ObjectModel;
    using System.Management.Automation.Runspaces;
    using System.Threading;
    using System.ComponentModel;
    namespace PowerShellLiveUpdateExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private BackgroundWorker bw = new BackgroundWorker();
            
            public MainWindow()
            {
                InitializeComponent();
                // Setup the BackgroundWorker
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                if (bw.IsBusy != true)
                {
                    bw.RunWorkerAsync();
                }
            }
            private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                textbox1.Text = (e.ProgressPercentage.ToString() + " %");
            }
            private void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                
                string scriptText = @"
                    function startExport() {
    	                $script:finishtime = (get-date).addminutes(1)
                    }
                    
                    function getPercentDone() {
    	                $timeleft = new-timespan $(get-date) $finishtime
                        return [math]::truncate(100 - ($timeleft.totalseconds / 60) * 100)
                    }
                    startExport";
                PowerShell psExec = PowerShell.Create();
                psExec.AddScript(scriptText);
                // Start the export
                psExec.Invoke();
                // Flush the currently added commands
                psExec.Commands.Clear();
                
                Collection<PSObject> results;
                Collection<ErrorRecord> errors;
                int percent = 0;
                // Report on the export
                while (percent < 100)
                {
                    // Update every second
                    Thread.Sleep(1000);
                    
                    psExec.AddScript("getPercentDone | out-string");
                    results = psExec.Invoke();
                    errors = psExec.Streams.Error.ReadAll();
                    foreach (PSObject obj in results)
                    {
                        Int32.TryParse(obj.ToString(), out percent);
                        worker.ReportProgress(percent);
                    }
                }
            }
            private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if ((e.Cancelled == true))
                {
                    textbox1.Text = "Canceled!";
                }
                else if (!(e.Error == null))
                {
                    textbox1.Text = ("Error: " + e.Error.Message);
                }
                else
                {
                    textbox1.Text = "Done!";
                }
            }
        }
    }
