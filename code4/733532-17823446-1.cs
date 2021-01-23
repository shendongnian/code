    public static class StringEnumConversion
    {
        public static int ConvertToEnum<T>(object value)
        {
            Contract.Requires(typeof(T).IsEnum);
            Contract.Requires(value != null);
            Contract.Requires(Enum.IsDefined(typeof(T), value.ToString()));
            return (int)Enum.Parse(typeof(T), value.ToString());
        }
    }
    
    [ContentProperty("Parameters")]
    public class PathConstructor : MarkupExtension
    {
        public string Path { get; set; }
        public IList Parameters { get; set; }
    
        public PathConstructor()
        {
            Parameters = new List<object>();
        }
    
        public PathConstructor(string b, object p0)
        {
            Path = b;
            Parameters = new[] { p0 };
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new PropertyPath(String.Format("{0}[{1}]",Path,StringEnumConversion.ConvertToEnum<Filters>(Parameters[0])));
        }
    }
