    /// <summary>
    /// Executes the specified action. If the action results in a file sharing violation exception, the action will be
    /// repeatedly retried after a short delay (which increases after every failed attempt).
    /// </summary>
    /// <param name="action">The action to be attempted and possibly retried.</param>
    /// <param name="maximum">Maximum amount of time to keep retrying for. When expired, any sharing violation
    /// exception will propagate to the caller of this method. Use null to retry indefinitely.</param>
    /// <param name="onSharingVio">Action to execute when a sharing violation does occur (is called before the waiting).</param>
    public static void WaitSharingVio(Action action, TimeSpan? maximum = null, Action onSharingVio = null)
    {
        WaitSharingVio<bool>(() => { action(); return true; }, maximum, onSharingVio);
    }
    /// <summary>
    /// Executes the specified function. If the function results in a file sharing violation exception, the function will be
    /// repeatedly retried after a short delay (which increases after every failed attempt).
    /// </summary>
    /// <param name="func">The function to be attempted and possibly retried.</param>
    /// <param name="maximum">Maximum amount of time to keep retrying for. When expired, any sharing violation
    /// exception will propagate to the caller of this method. Use null to retry indefinitely.</param>
    /// <param name="onSharingVio">Action to execute when a sharing violation does occur (is called before the waiting).</param>
    public static T WaitSharingVio<T>(Func<T> func, TimeSpan? maximum = null, Action onSharingVio = null)
    {
        var started = DateTime.UtcNow;
        int sleep = 279;
        while (true)
        {
            try
            {
                return func();
            }
            catch (IOException ex)
            {
                int hResult = 0;
                try { hResult = (int) ex.GetType().GetProperty("HResult", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ex, null); }
                catch { }
                if (hResult != -2147024864) // 0x80070020 ERROR_SHARING_VIOLATION
                    throw;
                if (onSharingVio != null)
                    onSharingVio();
            }
            if (maximum != null)
            {
                int leftMs = (int) (maximum.Value - (DateTime.UtcNow - started)).TotalMilliseconds;
                if (sleep > leftMs)
                {
                    Thread.Sleep(leftMs);
                    return func(); // or throw the sharing vio exception
                }
            }
            Thread.Sleep(sleep);
            sleep = Math.Min((sleep * 3) >> 1, 10000);
        }
    }
