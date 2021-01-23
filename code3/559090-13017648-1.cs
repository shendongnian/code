    dynamic obj = new MyDyn();
    Console.WriteLine(obj.Text);
    
    string methodName = "YourDynamicMethod";                    
            
    var p1 = new ParameterModifier(2);
    p1[0] = false; p1[1] = true;
    var args = new object[] { new MemberBinder(methodName, true), null };
            
    var res = typeof(DynamicObject).InvokeMember(
        "TryGetMember",
        BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public,
        null,
        obj,
        args,
        new ParameterModifier[] { p1 },
        null,
        null);
    var result = args[1];
---
    public class MyDyn : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = "#" + binder.Name + "#";
            return true;
        }
    }
    public class MemberBinder : GetMemberBinder
    {
        public MemberBinder(string name, bool ignoreCase) : base(name, ignoreCase)
        {
        }
        public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
        {
            throw new NotImplementedException();
        }
    }
