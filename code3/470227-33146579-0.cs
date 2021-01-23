    public class BusinessObject : DynamicObject 
    {
         private readonly IDictionary<string, object> dynamicProperties = 
             new Dictionary<string, object>();
         public override bool TryGetMember(GetMemberBinder binder, out object result)
         {
              var memberName = binder.Name;
              return dynamicProperties.TryGetValue(memberName, out result);
         }
         public override bool TrySetMember(SetMemberBinder binder, object value)
         {
              var memberName = binder.Name;
              dynamicProperties[memberName] = value;
              return true;
         }
    }
