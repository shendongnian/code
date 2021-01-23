    public class X: DynamicObject
    {
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }
    
    
    dynamic obj = new X();
    Console.WriteLine(obj.SomeProperty);
