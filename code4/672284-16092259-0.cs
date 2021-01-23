    public class PropertyBag : DynamicObject
    {
        private Dictionary<string, object> _propertyBag = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _propertyBag.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _propertyBag[binder.Name] = value;
            return true;
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return base.GetDynamicMemberNames();
        }
    }
