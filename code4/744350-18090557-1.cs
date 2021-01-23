    private SemaphoreSlim signal = new SemaphoreSlim(0, 1);
    
    private async Task<TrackballDecorator> loadModel(string path) {
        XamlReader xr = new XamlReader();
        xr.LoadCompleted += new AsyncCompletedEventHandler(AsyncXamlComplete);
        var tempVP = xr.LoadAsync(XmlReader.Create(path)) as Viewport3D;
    
        await signal.WaitAsync();
    
        return new TrackballDecorator() { Content = tempVP, Transform = tempVP.Camera.Transform as Transform3DGroup) };
    }
    
    private void AsyncXamlComplete(Object sender, AsyncCompletedEventArgs e) {
        signal.Release();
    }
