    private sealed class ImageSourceViewDataTemplateSelector: DataTemplateSelector
    {
        public ImageSourceViewDataTemplateSelector(... dependencies if any...)
        {             
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dataTemplate = null;
            IImageSourceViewModel instance = item as IImageSourceViewModel;
                    
            // move out into the constructor
            var dataTemplateFactory = new Dictionary<Type, Func<DataTemplate>>
                {
                        { typeof(ICameraSourceViewModel), (x) => this.Resources["CameraSourceDataTemplate"] as DataTemplate }, 
                        { typeof(IFileSourceViewModel), (x) => this.Resources["FileSourceViewModel"] as DataTemplate }
                };
    
            // TODO: handle not supported type case yourself
    
            return dataTemplateFactory[instance.GetType()]();
        }
    }
