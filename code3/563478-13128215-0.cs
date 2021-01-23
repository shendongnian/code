    public class EnumWrapper<T> where T:struct
    {
        private List<T> values;
        public List<T> Values
        {
            get { return values; }
            set { values = value; }
        }
        public EnumWrapper(Type type)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }
            Array a = Enum.GetValues(type);
            values = a.Cast<T>().ToList();
        }
    }
