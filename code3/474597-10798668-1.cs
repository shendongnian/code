    public class ForegroundCellStyleExtension : MarkupExtension
    {
        public ForegroundCellStyleExtension() { }
        public ForegroundCellStyleExtension(string propertyName)
        {
            PropertyName = propertyName;
        }
        public string PropertyName
        {
            get;
            set;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget service = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            DependencyObject targetObject = service.TargetObject as DependencyObject;
            if (targetObject == null)
            {
                return null;
            }
            Binding foregroundBinding = new Binding
            {
                Path = new PropertyPath(PropertyName),
                Converter = new ValueConverter()
            };
            Style foregroundCellStyle = new Style(typeof(DataGridCell));
            foregroundCellStyle.Setters.Add(new Setter(DataGridCell.ForegroundProperty, foregroundBinding));
            return foregroundCellStyle;
        }
    }
