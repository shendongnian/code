    public static readonly DependencyProperty ProcessedImageNameProperty = DependencyProperty.Register(
            "ProcessedImageName", typeof(string), typeof(ViewModel), new PropertyMetadata("Hello World"));
        public string ProcessedImageName {
    get { return (string)this.GetValue(ProcessedImageNameProperty); }
    set { this.SetValue(ProcessedImageNameProperty, value); }}
