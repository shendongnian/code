    public void OnChanged(object source, FileSystemEventArgs e)
    {
        this.Dispatcher.InvokeOrExecute(()=>{
           var imagePreview = new ImagePreview();
           imagePreview.Show();
        });
    }
