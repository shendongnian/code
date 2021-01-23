    public class QSValues : DynamicObject
        {
            readonly Dictionary<string, object> dynamicProperties = new Dictionary<string, object>();
    
            public string ErrorMessage { get; set; }
    
            public bool IsSuccessful { get; set; }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                dynamicProperties[binder.Name] = value;
    
                return true;
            }
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                return dynamicProperties.TryGetValue(binder.Name, out result);
            }
