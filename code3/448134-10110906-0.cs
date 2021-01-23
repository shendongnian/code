    class Program
    {
        static void Main(string[] args)
        {
            Gender gender = Gender.Unknown;
    
            switch (gender)
            {
                case Gender.Enum.Male:
                    break;
                case Gender.Enum.Female:
                    break;
                case Gender.Enum.Unknown:
                    break;
            }
        }
    }
    
    public class Gender : NameValue
    {
        private Gender(int value, string name)
            : base(value, name)
        {
        }
    
        public static readonly Gender Unknown = new Gender(Enum.Unknown, "Unknown");
        public static readonly Gender Male = new Gender(Enum.Male, "Male");
        public static readonly Gender Female = new Gender(Enum.Female, "Female");
        public class Enum
        {
            public const int Unknown = -1;
            public const int Male = 1;
            public const int Female = 2;
        }
    
    }
    
    public abstract class NameValue
    {
        private readonly int _value;
        private readonly string _name;
    
        protected NameValue(int value, string name)
        {
            _value = value;
            _name = name;
        }
    
        public int Value
        {
            get { return _value; }
        }
    
        public string Name
        {
            get { return _name; }
        }
    
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            NameValue other = obj as NameValue;
            if (ReferenceEquals(other, null)) return false;
            return this.Value == other.Value;
        }
    
        public static implicit operator int(NameValue nameValue)
        {
            return nameValue.Value;
        }
    }
