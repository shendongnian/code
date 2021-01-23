    public void UpdateChatContent()
    {
        var myVar=(from a in db select a).Tolist();
        OnUIThread(() => datagrid1.ItemsSource=myVar);
    }
    private void OnUIThread(Action action)
    {
        if(Dispatcher.CheckAccess())
        {
            action();
        }
        else
        {
            // if you don't want to block the current thread while action is
            // executed, you can also call Dispatcher.BeginInvoke(action);
            Dispatcher.Invoke(action);
        }
    }
