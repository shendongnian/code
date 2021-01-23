    public class NinjectConverter : IConverter
    {
        private readonly Kernel kernel;
        public NinjectConverter(Kernel kernel)
        {
            this.kernel = kernel;
        }
        public object Convert(object value, Type targetType)
        {
            var converterType =
                typeof(IConverter<>).MakeGenericType(targetType);
            dynamic converter = this.kernel.Get(converterType);
            return converter.Convert(value);
        }
    }
