    public class BindingProxy : Freezable
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Data", 
            typeof(object), 
            typeof(BindingProxy),
            new UIPropertyMetadata(null));
    
        public object Data
        {
            get { return this.GetValue(DataProperty); }
            set { this.SetValue(DataProperty, value); }
        }
    
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
    }
