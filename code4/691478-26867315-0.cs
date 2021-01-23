    public static class TryWithAwaitInCatch
    {
        public static async Task ExecuteAndHandleErrorAsync(Func<Task> actionAsync,
            Func<Exception, Task<bool>> errorHandlerAsync)
        {
            ExceptionDispatchInfo capturedException = null;
            try
            {
                await actionAsync();
            }
            catch (Exception ex)
            {
                capturedException = ExceptionDispatchInfo.Capture(ex);
            }
            if (capturedException != null)
            {
                bool needsThrow = await errorHandlerAsync(capturedException.SourceException);
                if (needsThrow)
                {
                    capturedException.Throw();
                }
            }
        }
    }
