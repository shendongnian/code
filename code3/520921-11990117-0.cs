    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : Attribute
    {
        public string ParameterName { get; private set; }
        public ParameterAttribute(string parameterName)
        {
            ParameterName = parameterName;
        }
    }
