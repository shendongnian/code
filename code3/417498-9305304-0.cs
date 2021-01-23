 void someEvent_Handler(object sender, SomeEventEventArgs e)
{
    if (this.Dispatcher.CheckAccess())
    {
        // do work on UI thread
    }
    else
    {
        // or BeginInvoke()
        this.Dispatcher.Invoke(new Action<object, SomeEventEventArgs>(someEvent_Handler), 
            sender, e);
    }
}
