    interface IKeyValue<TKey, TValue>
    {
       public TKey Key {get;set;}
       public TValue Value {get;set;}
    }
    public class Attribute : IKeyValue<string, string>
    {
       public override string ToString() 
       {
            return String.Format("{0}={1}:{2}", Constants.ATTRIBUTE_CHAR, Key, Value);
       }
    }
    public class BoolAttribute : IKeyValue<string, bool>
    {
       public override string ToString() 
       {
            return Value ? String.Format("{0}={1}", Constants.ATTRIBUTE_CHAR, Key) : String.Empty;
       }
    }
