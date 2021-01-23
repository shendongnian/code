        public abstract class Model : DynamicObject
    {
        public virtual object __get(string propertyName)
        {
            return null;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if ((result = this.__get(binder.Name)) != null)
                return true;
            return base.TryGetMember(binder, out result);
        }
        public virtual void __set(string propertyName, object value)
        {
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.__set(binder.Name, value);
            return true;
        }
    }
