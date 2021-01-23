    public class ReflectionReader : PatternLayoutConverter
    {
        public ReflectionReader()
        {
            _getValue = GetValueFirstTime;
        }
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            writer.Write(_getValue(loggingEvent.MessageObject));
        }
        private Func<object, String> _getValue;
        private string GetValueFirstTime(object source)
        {
            _targetProperty = source.GetType().GetProperty(Option);
            if (_targetProperty == null)
            {
                _getValue = x => "<NULL>";
            }
            else
            {
                _getValue = x => String.Format("{0}", _targetProperty.GetValue(x, null));
            }
            return _getValue(source);
        }
        private PropertyInfo _targetProperty;
    }
