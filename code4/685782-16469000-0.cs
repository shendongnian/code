    Task.Factory
    .StartNew(() =>
    {
        return Gateway.Authenticate(a, b);
    })
    .ContinueWith((t) =>
    {
        if (t.Exception == null)
        {
           DoSomeUI(t.Result);
        }else{
           //Handle Exception Message
        }
    }
    );
