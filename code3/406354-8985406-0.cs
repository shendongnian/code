        internal abstract class ApplicationPrinter : IDisposable
        {
            protected abstract string applicationName { get; }
            protected string filename;
            protected string printer;
            protected bool workerPrintOk;
            protected bool printOk;
            public bool PrintOk { get { return printOk; } }
            public bool KillApplicationOnClose { get; set; }
            protected System.Threading.Thread worker;
            protected volatile bool isPrinting;
            public void Print()
            {
                worker = new System.Threading.Thread(printWorker);
                DateTime time = DateTime.Now;
                worker.Start();
                if (worker.Join(new TimeSpan(0, Email2Pdf.Settings.Printer.FileGenerateTimeOutMins, 0)))
                {
                    printOk = workerPrintOk;
                }
                else
                {
                    AbortPrintWorker();
                    printOk = false;
                    Logging.Log("Timed out waiting for " + applicationName + " file " + filename + " to print.", Logging.LogLevel.Error);
                }
            }
            protected abstract void printWorker();
            public abstract void Dispose();
            private void AbortPrintWorker()
            {
                System.Threading.Thread abortThread = new System.Threading.Thread(abortWorker);
                if (isPrinting)
                {
                    abortThread.Start();
                    System.Threading.Thread.Sleep(0);
                    abortThread.Join();
                }
                else
                {
                    worker.Join();
                }
            }
            private void abortWorker()
            {
                worker.Abort();
                worker.Join();
            }
        }
        internal class PowerPointPrinter : ApplicationPrinter
        {
            private const string appName = "PowerPoint";
            protected override string applicationName { get { return appName; } }
            private Microsoft.Office.Interop.PowerPoint.Application officePowerPoint = null;
            public PowerPointPrinter(string Filename, string Printer)
            {
                filename = Filename;
                printer = Printer;
                this.Dispose();
            }
            protected override void printWorker()
            {
                try
                {
                    isPrinting = true;
                    officePowerPoint = new Microsoft.Office.Interop.PowerPoint.Application();
                    officePowerPoint.DisplayAlerts = Microsoft.Office.Interop.PowerPoint.PpAlertLevel.ppAlertsNone;
                    Microsoft.Office.Interop.PowerPoint.Presentation doc = null;
                    doc = officePowerPoint.Presentations.Open(
                        filename,
                        Microsoft.Office.Core.MsoTriState.msoTrue,
                        Microsoft.Office.Core.MsoTriState.msoFalse,
                        Microsoft.Office.Core.MsoTriState.msoFalse);
                    doc.PrintOptions.ActivePrinter = printer;
                    doc.PrintOptions.PrintInBackground = Microsoft.Office.Core.MsoTriState.msoFalse;
                    doc.PrintOptions.OutputType = Microsoft.Office.Interop.PowerPoint.PpPrintOutputType.ppPrintOutputSlides;
                    doc.PrintOut();
                    System.Threading.Thread.Sleep(500);
                    doc.Close();
                    Marshal.FinalReleaseComObject(doc);
                    doc = null;
                    workerPrintOk = true;
                    isPrinting = true;
                }
                catch (System.Exception ex)
                {
                    isPrinting = false;
                    
                    Logging.Log("Unable to print PowerPoint file " + filename + ". Exception: " + ex.Message, Logging.LogLevel.Error);
                    workerPrintOk = false;
                }
            }
            public override void Dispose()
            {
                try
                {
                    if (officePowerPoint != null)
                        officePowerPoint.Quit();
                    Marshal.FinalReleaseComObject(officePowerPoint);
                    officePowerPoint = null;
                    if (KillApplicationOnClose)
                        Utility.KillProcessesByName(OfficePowerPointExe);
                }
                catch { }
            }
        }
