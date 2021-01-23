    public interface IAttribute<out T>
    {
        T Description { get; }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class CarStatusAttribute : Attribute, IAttribute<string>
    {
        private readonly string _value;
        public CarStatusAttribute(string value)
        {
            _value = value;
        }
        public string Description
        {
            get { return _value; }
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class IsErrorAttribute : Attribute, IAttribute<bool>
    {
        private readonly bool _value;
        public IsErrorAttribute(bool value)
        {
            _value = value;
        }
        public bool Description
        {
            get { return _value; }
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class IsUsingPetrolAttribute : Attribute, IAttribute<bool>
    {
        private readonly bool _value;
        public IsUsingPetrolAttribute(bool value)
        {
            _value = value;
        }
        public bool Description
        {
            get { return _value; }
        }
    }
