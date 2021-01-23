    private async Task SavePhoto1()
    {
        try
        {
            WriteableBitmap wb1 = null;
            await ExecuteOnUIThread(() =>
            {
                wb1 = new WriteableBitmap(320, 240);//throw exception
            });
            
            // do something with wb1 here
            wb1.DoSomething();
        }catch (Exception ee)
        {
            String s = ee.ToString();
        }
    }    
    public static IAsyncAction ExecuteOnUIThread(Windows.UI.Core.DispatchedHandler action)
    {
        return Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, action);
    }
