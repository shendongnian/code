    public class MyContractResolver: DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var members = base.GetSerializableMembers(objectType);
            var filteredMembers = new List<MemberInfo>();
            members.ForEach(m=>{
                if(m.MemberType == MemberTypes.Property)
                {
                    PropertyInfo info = (PropertyInfo) m;
                    var type = info.PropertyType;
                    if(type.IsPrimitive || type == typeof(string) || type == typeof(decimal))
                    {
                        filteredMembers.Add(m);
                    }
                }
            });
            return filteredMembers;
        }
    }
