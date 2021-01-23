        private IAsyncInfo mActiveDialogOperation = null;
        private object mOperationMutex = new object();
        private void ClearActiveOperation(IAsyncInfo operation)
        {
            lock (mOperationMutex)
            {
                if (mActiveDialogOperation == operation)
                    mActiveDialogOperation = null;
            }
        }
        private void SetActiveOperation(IAsyncInfo operation)
        {
            lock (mOperationMutex)
            {
                if (mActiveDialogOperation != null)
                {
                    mActiveDialogOperation.Cancel();
                }
                mActiveDialogOperation = operation;
            }
        }
        public void StopActiveOperations()
        {
            SetActiveOperation(null);
        }
        public async void ShowDialog(MessageDialog dialog)
        {
            StopActiveOperations();
            try
            {
                IAsyncOperation<IUICommand> newOperation = dialog.ShowAsync();
                SetActiveOperation(newOperation);
                await newOperation;
                ClearActiveOperation(newOperation);
            }
            catch (System.Threading.Tasks.TaskCanceledException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
