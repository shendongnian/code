    abstract class MyTypedString
    {
       protected MyTypedString(string value)
       {
         Value = value;
       }
       public string Value { get; private set; }
    }
