    [AttributeUsage(AttributeTargets.Assembly)]
    public class TraceAttribute : Attribute
    {
        public TraceAttribute(string traceConfigKey)
        {
            var keyValue = ConfigurationManager.AppSettings[traceConfigKey];
            DoTracing = !string.IsNullOrEmpty(keyValue) && bool.Parse(keyValue);
        }
        /// <summary>
        /// Use this property for your tracing conditional logic.
        /// </summary>
        public bool DoTracing { get; private set; }
    }
