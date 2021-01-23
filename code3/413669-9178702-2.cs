    public class BaseViewModel : ObservableObject
    {
        private static Nullable<Boolean> _isInDesignMode;
    
        public Boolean IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    DependencyProperty property = DesignerProperties.IsInDesignModeProperty;
    
                    _isInDesignMode
                        = (bool)DependencyPropertyDescriptor
                                        .FromProperty(property, typeof(FrameworkElement))
                                        .Metadata.DefaultValue;
                }
    
                return _isInDesignMode.Value;
            }
        }
    }
