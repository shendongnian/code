    /// <summary>
    /// Provides a easy to use timer. 
    /// Usage
    /// using(new DiagnosticTimer())
    /// {
    ///     // do anything
    /// }
    /// </summary>
    public class DiagnosticTimer : IDisposable
    {
        public System.Diagnostics.Stopwatch StopWatch { get; protected set; }
        public string Message { get; set; }
        public DiagnosticTimer()
        {
            Message = "Diagnostic Timer at " + new System.Diagnostics.StackTrace().GetFrame(1).ToString();
            StopWatch = new System.Diagnostics.Stopwatch();
            StopWatch.Start();
        }
        public DiagnosticTimer(string Message)
        {
            this.Message = Message;
            StopWatch = new System.Diagnostics.Stopwatch();
            StopWatch.Start();
        }
        public void Dispose()
        {
            StopWatch.Stop();
            System.Diagnostics.Trace.WriteLine(Message + StopWatch.Elapsed.ToString());
        }
    }
