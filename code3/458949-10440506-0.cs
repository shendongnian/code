    void PerformLoadImageTask(CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
             Console.WriteLine("Task {0}: Cancelling", Task.CurrentId);
             return;
        }
        using (var pool = new NSAutoreleasePool ()) {
            current_uiimage_A = UIImage.FromFileUncached(file_name);
            page_A_image_view.Image = current_uiimage_A;
        }
    }
