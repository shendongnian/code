    public class DatePartValueConverter : MarkupExtension, IValueConverter {
        public string ParseType { get; set; }
        // other methods
    }
    <TextBlock Text="{Binding Path=Value, ElementName=window,
      Converter={local:DatePartValueConverter ParseType=M}}" />
