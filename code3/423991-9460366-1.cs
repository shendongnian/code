    namespace System.Web.Compilation
    {
        public interface IResourceProvider
        {
            IResourceReader ResourceReader { get; }
            object GetObject(string resourceKey, CultureInfo culture);
        }
    }
