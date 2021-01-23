    [ContentProperty("Name")]
    public class Reference : System.Windows.Markup.Reference
    {
        private static DependencyObject _dependencyObject = new DependencyObject();
        public Reference()
            : base()
        { }
        public Reference(string name)
            : base(name)
        { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (DesignerProperties.GetIsInDesignMode(_dependencyObject) == true)
            {
                return null;
            }
            return base.ProvideValue(serviceProvider);
        }
    }
