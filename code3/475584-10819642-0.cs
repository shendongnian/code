    //your class where you h
    public class MyProperty
    {
        public bool IsVisible {get;set;} //TRUE if prperty is Visible to others, FALSE otherwise
        public string PropertyName {get;set;} 
       
    }
    public class DynamicDictionary : DynamicObject
    {
        // The inner dictionary.
        Dictionary<MyProperty, object> dictionary
            = new Dictionary<MyProperty, object>();
    
         .....
    
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            ...
        }
    
      
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            ...
        }
    }
