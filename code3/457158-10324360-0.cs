    public class BaseClass
    {
        // Factory Pattern
        public static BaseClass Create(string Input)
        {
            if (Input.Substring(0, 5) == "Something")
                return new DerivedClass(); // <-- allowed
            return new BaseClass();
        }
    }
