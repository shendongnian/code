    Application.Current.Dispatcher.Invoke(() => {
    try
    {
    richTextBox1.Text += string.Format("ID:{0} online:{1}", user.uid, user.online);
    }
    catch
    {
       //handle
    }
    ), DispatcherPriority.Background);
