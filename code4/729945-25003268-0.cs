    public class ViewModel
    {
        public ViewModel()
        {
            if (!IsInDesignMode)
            {
                //Constructor code here...
            }
        }
        public bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor
                    .FromProperty(prop, typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }
    }
