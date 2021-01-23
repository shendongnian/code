    public interface IValueProviderFactory
    {
        IValueProvider CreateProvider(string option);
    }
    public class ValueProviderFactory : IValueProviderFactory
    {
        public IValueProvider CreateProvider(string option)
        {
             // Insert custom instantiation logic here:
             // if option == "value1" return ValueProvider1 and so on
        }
    }
    public class InformationService : IInformationService
    {
        private readonly IValueProviderFactory _valueProviderFactory;
        public InformationService(IValueProvider valueProviderFactory)
        {
            _valueProviderFactory = valueProviderFactory;
        }
        public CompanyReportResponse CompanyReport(string option)
        {
            var valueProvider = _valueProviderFactory.CreateProvider(option);
            valueProvider.Execute(option);
        }
    }
