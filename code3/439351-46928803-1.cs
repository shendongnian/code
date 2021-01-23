    parent.Dispatcher.Invoke(new Action(() =>
    {
        cameraImage.Lock();
        cameraImage.AddDirtyRect(new Int32Rect(0, 0, cameraImage.PixelWidth, cameraImage.PixelHeight));
        cameraImage.Unlock();
    }), DispatcherPriority.Render);
