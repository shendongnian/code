        /// <summary>
        /// Class responsible for getting the right format resolver for a given type
        /// </summary>
        public class FormatterResolver
        {
            private ObjectPropertyFormatter _objectPropertyFormatter;
            private Dictionary<Type, object> _registeredFormatters;
            public FormatterResolver()
            {
                _registeredFormatters = new Dictionary<Type, object>();
                _objectPropertyFormatter = new ObjectPropertyFormatter();
            }
            public void RegisterFormatter<T>(IPropertyFormatter<T> formatter)
            {
                _registeredFormatters.Add(typeof(T), formatter);
            }
            public Func<string> GetFormatterFunc<T>(T value)
            {
                object formatter;
                if (_registeredFormatters.TryGetValue(typeof(T), out formatter))
                {
                    return () => (formatter as IPropertyFormatter<T>).FormatValue(value);
                }
                else
                    return () => ( _objectPropertyFormatter.FormatValue(value));
            }
        }
