    public class StatusBarRegionSelector : DataTemplateSelector
        {
            public DataTemplate SimpleTextTemplate { get; set; }
            public DataTemplate ErrorTemplate { get; set; }
            public DataTemplate ProgressBarTemplate { get; set; }
    
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                var statusBar = (StatusBar) item;
    
                if (statusBar != null)
                    switch (statusBar.Type)
                    {
                        case StatusBarAreaType.SimpleText:
                            return SimpleTextTemplate;
                            break;
                        case StatusBarAreaType.Error:
                            return ErrorTemplate;
                            break;
                        case StatusBarAreaType.ProgressBar:
                            return ProgressBarTemplate;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
    
                return SimpleTextTemplate;
            }
        }
