    public class DynamicElement : DynamicObject
    {
        public Dictionary<string, object> Attributes
        {
            get { return lst; }
        }
        private Dictionary<string, object> lst;
        public DynamicElement()
        {
            lst = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }
        public bool Present(string name)
        {
            if (lst == null) return false;
            if (!lst.ContainsKey(name)) return false;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;
            result = null;
            if (lst == null) return false;
            if (!lst.ContainsKey(name)) return false;
            result = lst[name];
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var name = binder.Name;
            if (lst == null) return false;
            if (!lst.ContainsKey(name))
                lst.Add(name, value);
            else
                lst[name] = value;
            return true;
        }
    }
