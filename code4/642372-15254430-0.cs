    public class Register
    {
        private int value;
        internal Register(int value)
        {
            this.value = value;
        }
        public static readonly Register NonSpecialRegister = new Register(0);
        public static readonly Register OtherNonSpecialRegister = new Register(1);
        public static readonly SpecialRegister SpecialRegister 
            = SpecialRegister.SpecialRegister;
        public static readonly SpecialRegister OtherSpecialRegister 
            = SpecialRegister.OtherSpecialRegister;
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Register other = obj as Register;
            if (obj == null)
                return false;
            return other.value == value;
        }
    }
    public class SpecialRegister : Register
    {
        internal SpecialRegister(int value) : base(value) { }
        public static readonly SpecialRegister SpecialRegister = new SpecialRegister(2);
        public static readonly SpecialRegister OtherSpecialRegister = new SpecialRegister(3);
    }
