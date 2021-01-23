    /// <summary>
    /// MessageDialog extension methods
    /// </summary>
    public static class MessageDialogExtensions
    {
        private static TaskCompletionSource<MessageDialog> _currentDialogShowRequest;
        /// <summary>
        /// Begins an asynchronous operation showing a dialog.
        /// If another dialog is already shown using
        /// ShowAsyncQueue or ShowAsyncIfPossible method - it will wait
        /// for that previous dialog to be dismissed before showing the new one.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">This method can only be invoked from UI thread.</exception>
        public static async Task ShowAsyncQueue(this MessageDialog dialog)
        {
            if (!Window.Current.Dispatcher.HasThreadAccess)
            {
                throw new InvalidOperationException("This method can only be invoked from UI thread.");
            }
            while (_currentDialogShowRequest != null)
            {
                await _currentDialogShowRequest.Task;
            }
            var request = _currentDialogShowRequest = new TaskCompletionSource<MessageDialog>();
            await dialog.ShowAsync();
            _currentDialogShowRequest = null;
            request.SetResult(dialog);
        }
        /// <summary>
        /// Begins an asynchronous operation showing a dialog.
        /// If another dialog is already shown using
        /// ShowAsyncQueue or ShowAsyncIfPossible method - it will wait
        /// return immediately and the new dialog won't be displayed.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">This method can only be invoked from UI thread.</exception>
        public static async Task ShowAsyncIfPossible(this MessageDialog dialog)
        {
            if (!Window.Current.Dispatcher.HasThreadAccess)
            {
                throw new InvalidOperationException("This method can only be invoked from UI thread.");
            }
            while (_currentDialogShowRequest != null)
            {
                return;
            }
            var request = _currentDialogShowRequest = new TaskCompletionSource<MessageDialog>();
            await dialog.ShowAsync();
            _currentDialogShowRequest = null;
            request.SetResult(dialog);
        }
    }
