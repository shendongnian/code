    public class MyTypeAttribute : Attribute
        {
            private readonly Type Type;
            public MyTypeAttribute (Type type)
            {
                Type = type;
            }
            public override string ToString()
            {
                return Type.ToString();
            }
        }
