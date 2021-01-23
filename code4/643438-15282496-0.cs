    private Size GetDpiSafeResolution()
    {
        PresentationSource _presentationSource = PresentationSource.FromVisual(Application.Current.MainWindow);
        Matrix matix = _presentationSource.CompositionTarget.TransformToDevice;
        return new Size(SystemParameters.PrimaryScreenHeight * matix.M11, SystemParameters.PrimaryScreenWidth * matix.M22);
    }
