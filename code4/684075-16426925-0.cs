    public void CheckTheDataContext()
    {
        // is it null?
        if(this.DataContext == null)
        {
            // then drop an Action re-invoking this method later
            // when the application idles out a bit
            Dispatcher.BeginInvoke((Action)(() =>
            {
                CheckTheDataContext();
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            return;
        }
        DoSomethingElseWithTheContext(DataContext);
    }
