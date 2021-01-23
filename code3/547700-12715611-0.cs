    public static void OnChanged(object source, FileSystemEventArgs e)
    {
        var d = Application.Current.Dispatcher;
        if (d.CheckAccess())
            OnChangedInMainThread();
        else
            d.BeginInvoke((Action)OnChangedInMainThread);
    }
    void OnChangedInMainThread()
    {
        var imagePreview = new ImagePreview();
        imagePreview.Show();
    }
