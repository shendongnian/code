    using System.Globalization;
    
    namespace WpfApplication
    {
        public interface IProposedValueErrorInfo
        {
            object GetError(string propertyName, object value, CultureInfo cultureInfo);
        }
    }
