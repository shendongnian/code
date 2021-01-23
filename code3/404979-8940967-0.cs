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
            Dispatcher.Invoke(action);
        }
    }
