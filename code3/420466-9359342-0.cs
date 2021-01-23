    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.DoWorkComplete += (s, e) => Console.WriteLine(e.Result);
            program.DoWorkAsync();
            // Wait 10 seconds, worker thread should finish beforehand, so
            // you see console output
            Thread.Sleep(10000);
        }
        public event EventHandler<CompleteEventArgs> DoWorkComplete;
        public void DoWorkAsync()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                // Download data here
                string result = "Result from Wiki";
                if(DoWorkComplete != null)
                    DoWorkComplete(this, new CompleteEventArgs(result));
            });
        }
        public class CompleteEventArgs : EventArgs
        {
            public CompleteEventArgs(string result)
            {
                this.Result = result;
            }
            public string Result { get; private set; }
        }
    }
