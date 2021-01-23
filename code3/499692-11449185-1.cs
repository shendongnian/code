    public class X : DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
    
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();
    
            return dictionary.TryGetValue(name, out result);
        }
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name.ToLower()] = value;
            return true;
        }
    }
        
        
    dynamic obj = new X();
    obj.SomeProperty = "Test";
    Console.WriteLine(obj.SomeProperty);
