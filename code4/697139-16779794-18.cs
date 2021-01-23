    private Intent _lastData;    
    // Starts activity for results and waits for this result. Calling function may
    // inspect _lastData private member to get this result, or null if any error.
    // For sure, it could be written better to avoid class-wide _lastData member...
    private async Task StartActivityForResultAsync(Intent intent, int requestCode)
    {
        try
        {
            _lastData = null;
            Event1.Reset();
            StartActivityForResult(intent, requestCode);
                // possible exceptions: ActivityNotFoundException, also got SecurityException from com.turboled
            await Task.Run(delegate { Event1.WaitOne(); });
        }
        catch (Exception)
        {
        }
    }
