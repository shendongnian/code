    public class ForegroundCellStyleExtension : MarkupExtension
    {
        public ForegroundCellStyleExtension() { }
        public ForegroundCellStyleExtension(string propertyName, Style basedOnCellStyle)
        {
            PropertyName = propertyName;
            BasedOnCellStyle = basedOnCellStyle;
        }
        public string PropertyName
        {
            get;
            set;
        }
        public Style BasedOnCellStyle
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
            Style foregroundCellStyle = new Style(typeof(DataGridCell), BasedOnCellStyle);
            foregroundCellStyle.Setters.Add(new Setter(DataGridCell.ForegroundProperty, foregroundBinding));
            return foregroundCellStyle;
        }
    }
