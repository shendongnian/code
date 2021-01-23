    public class MainClass
    {
        private CancellationTokenSource = source;
        private CancellationToken token;
        
        public MainClass()
        {
            source = new CancellationtokenSource();
            token = source.Token;
        }
        private void buttonProcessSel_Click(object sender, EventArgs e)
        {
            // Spin-off MyMethod on background thread.
            Task<bool> asyncControllerTask = null;
            TaskSpin(asyncControllerTask, cancelSource, token, MyMethod);
        }
        private void method()
        {
            // Use the global token DOES NOT work!
            if (token.IsCancellationRequested)		
                token.ThrowIfCancellationRequested();
        }
        private void TaskSpin(Task<bool> asyncTask, CancellationTokenSource cancelSource,
            CancellationToken token, Func<bool> asyncMethod)
        {
            try
            {
                token = cancelSource.Token;
                asyncTask = Task.Factory.StartNew<bool>(() => asyncMethod(token), token);
                // To facilitate multitasking the cancelTask ToolStripButton
                EventHandler cancelHandler = null;
                if (cancelSource != null)
                {
                    cancelHandler = delegate
                    {
                        UtilsTPL.CancelRunningProcess(mainForm, uiScheduler, asyncTask, cancelSource, true);
                    };
                }
			// Callback for finish/cancellation.
                asyncTask.ContinueWith(task =>
                {
                    // Handle cancellation etc.
                }
                // Other stuff...
            }
        }
    }
