    public class MyJsonFormatter : JsonMediaTypeFormatter
        {
            public override bool CanWriteType(Type type)
            {
                return type == typeof(MyClass);
            }
        }
