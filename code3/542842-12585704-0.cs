    public static DependencyProperty SignatureProperty = DependencyProperty.Register(
        "Signature",
        typeof(string),
        typeof(ucSignature),
        new UIPropertyMetadata(OnSignaturePropertyChanged));
    public static string GetSignature(ucSignature signature)
    {
        return (string)signature.GetValue(SignatureProperty);
    }
    public static void SetSignature(ucSignature signature, string value)
    {
        signature.SetValue(SignatureProperty, value);
    }
    private static void OnSignaturePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        //this method should handle any RaisePropertyChanged events from your
        //view model as a result of the binding in your user control XAML                       
    }
