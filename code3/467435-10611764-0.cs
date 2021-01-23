    namespace MyNamespace
    {
        public class CustomBinding : Binding
        {
            public CustomBinding(String path)
                : base(path)
            {
                this.Converter = new CustomValueConverter();
                this.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                this.ValidatesOnDataErrors = true;
            }
        }
    }
