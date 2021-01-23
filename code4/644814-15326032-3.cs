    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
       if (navigationParameter != null)
       {
            String msg = (String) navigationParameter;
            var popup = new Windows.UI.Popups.MessageDialog(msg, "Some title");
            await popup.ShowAsync();
       }
    }
