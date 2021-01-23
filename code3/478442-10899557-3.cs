    public class MyClass
    {
        // Not a predefined instance of the containing Type => property
        // It's constant today, but who knows, tomorrow its value may come from a 
        // configuration file.
        public static Color MyColor { get { return Color.Red; } }
    }
