    public static class MessageDialogShower
    {
        private static SemaphoreSlim _semaphore;
 
        static MessageDialogShower()
        {
            _semaphore = new SemaphoreSlim(1);
        }
 
        public static async Task<IUICommand> ShowDialogSafely(this MessageDialog dialog)
        {
            await _semaphore.WaitAsync();
            var result = await dialog.ShowAsync();
            _semaphore.Release();
            return result;
        }
    }
