    public class DynamicAnonymous : DynamicObject
    {
                object obj;
                public DynamicAnonymous(object o)
                {
                        this.obj = o;
                }
                public override IEnumerable<string> GetDynamicMemberNames()
                {
                        return obj.GetType().GetProperties().Select(n => n.Name);
                }
                public override bool TryGetMember(GetMemberBinder binder, out object result)
                {
                        var prop = obj.GetType().GetProperty(binder.Name);
                        if (prop == null)
                        {
                                result = null;
                                return false;
                        }
                        else
                        {
                                result = prop.GetValue(obj, null);
                                return true;
                        }
                }
                public override int GetHashCode()
                {
                        return obj.GetHashCode();
                }
                public override string ToString()
                {
                        return obj.ToString();
                }
                public override bool Equals(object obj2)
                {
                        return obj.Equals(obj2);
                }                
     }
