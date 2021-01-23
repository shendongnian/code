    public void metaSync(int handle, int channle, int data, IntPtr user)
    {
        [...]
    
        //Tags just gets the meta data from the file stream
        Tags t = new Tags(_url, _stream);
        t.getTags();
    
        //throws InvalidOperationException - Already used in another thread
        //_window.lblTag.Content = "Content" + t.title;
        _window.lblTag.Dispatcher.BeginInvoke((Action)(() =>
                {
                    _window.lblTag.Content = "Content" + t.title;
                }));
    }
