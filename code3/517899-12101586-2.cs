    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.Threading;
    namespace CSharpLayer
    {
        class SandboxCppProgress
        {
            public delegate void ReportProgressCallback(int percentage, string message);
            public delegate bool CancellationPendingCallback();
            [StructLayout(LayoutKind.Sequential)]
            public class WorkProgressInteropNegotiator
            {
                public ReportProgressCallback reportProgress;
                public CancellationPendingCallback cancellationPending;
    #pragma warning disable 0649
                // C# does not see this member is set up in native code, we disable warning to avoid it.
                public bool cancel;
    #pragma warning restore 0649
            }
            [DllImport("CppLayer.dll")]
            public static extern void CppLongFunction([In, Out] WorkProgressInteropNegotiator negotiator);
            static void CSharpLongFunctionWrapper(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                WorkProgressInteropNegotiator negotiator = new WorkProgressInteropNegotiator();
                negotiator.reportProgress = new ReportProgressCallback(bw.ReportProgress);
                negotiator.cancellationPending = new CancellationPendingCallback(() => bw.CancellationPending);
            
                // Refer for details to
                // "How to: Marshal Callbacks and Delegates Using C++ Interop" 
                // http://msdn.microsoft.com/en-us/library/367eeye0%28v=vs.100%29.aspx
                GCHandle gch = GCHandle.Alloc(negotiator);
                CppLongFunction(negotiator);
                gch.Free();
                e.Cancel = negotiator.cancel;
            }
 
            static EventWaitHandle resetEvent = null;
            static void CSharpReportProgressStatus(object sender, ProgressChangedEventArgs e)
            {
                string message = e.UserState as string;
                Console.WriteLine("Report {0:00}% with message '{1}'", e.ProgressPercentage, message);
                BackgroundWorker bw = sender as BackgroundWorker;
                if (e.ProgressPercentage > 50)
                    bw.CancelAsync();
            }
            static void CSharpReportComplete(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                {
                    Console.WriteLine("Long operation canceled!");
                }
                else if (e.Error != null)
                {
                    Console.WriteLine("Long operation error: {0}", e.Error.Message);
                }
                else
                {
                    Console.WriteLine("Long operation complete!");
                }
                resetEvent.Set();
            }
            public static void Main(string[] args)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.ProgressChanged += CSharpReportProgressStatus;
                bw.DoWork += CSharpLongFunctionWrapper;
                bw.RunWorkerCompleted += CSharpReportComplete;
                resetEvent = new AutoResetEvent(false);
                bw.RunWorkerAsync();
                resetEvent.WaitOne();
            }
        }
    }
