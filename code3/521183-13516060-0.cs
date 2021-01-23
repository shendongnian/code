    using System;
    using Caliburn.Micro;
    using System.ComponentModel;
    namespace MyApp.Implementation
    {
        public class BackgroundCoRoutine : IResult
        {
            private readonly System.Action action;
            public BackgroundCoRoutine(System.Action action)
            {
                this.action = action;
            }
            public void Execute(ActionExecutionContext context)
            {
                using (var backgroundWorker = new BackgroundWorker())
                {
                    backgroundWorker.DoWork += (e, sender) => action();
                    backgroundWorker.RunWorkerCompleted += (e, sender) => Completed(this, new ResultCompletionEventArgs());
                    backgroundWorker.RunWorkerAsync();
                }
            }
            public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
        }
    }
