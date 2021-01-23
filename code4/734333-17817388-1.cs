    public static class MessageDialogDisplayer
    {
        private static readonly ConcurrentQueue<MessageDialog> _dialogQueue;
        private static readonly CancellationTokenSource _cancellationTokenSource;
        static MessageDialogDisplayer()
        {
            _dialogQueue = new ConcurrentQueue<MessageDialog>();
            _cancellationTokenSource = new CancellationTokenSource();
            new Task(DisplayQueuedDialogs, _cancellationTokenSource.Token).Start();
        }
        public static void DisplayDialog(MessageDialog dialog)
        {
            _dialogQueue.Enqueue(dialog);
        }
        private static async void DisplayQueuedDialogs()
        {
            const int millisecondsBetweenDialogChecks = 500;
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                MessageDialog dialogToDisplay;
                if (_dialogQueue.TryDequeue(out dialogToDisplay))
                {
                    await dialogToDisplay.ShowAsync();
                }
                else
                {
                    await Task.Delay(millisecondsBetweenDialogChecks);
                }
            }
        }
    }
