    public class IgnoreDataContractContractResolver : DefaultContractResolver
    {
        static MemberSerialization RemoveDataContractAttributeMemberSerialization(Type type, MemberSerialization memberSerialization)
        {
            if (memberSerialization == MemberSerialization.OptIn)
            {
                type = Nullable.GetUnderlyingType(type) ?? type;
                // Json.NET interprets DataContractAttribute as inherited despite the fact it is marked with Inherited = false
                // https://json.codeplex.com/discussions/357850
                // https://stackoverflow.com/questions/8555089/datacontract-and-inheritance
                // https://github.com/JamesNK/Newtonsoft.Json/issues/603
                // Thus we need to manually climb the type hierarchy to see if one is present.
                var dataContractAttribute = type.BaseTypesAndSelf().Select(t => t.GetCustomAttribute<DataContractAttribute>()).FirstOrDefault(a => a != null);
                var jsonObjectAttribute = type.GetCustomAttribute<JsonObjectAttribute>();
                if (dataContractAttribute != null && jsonObjectAttribute == null)
                    memberSerialization = MemberSerialization.OptOut;
            }
            return memberSerialization;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, RemoveDataContractAttributeMemberSerialization(type, memberSerialization));
            return properties;
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            contract.MemberSerialization = RemoveDataContractAttributeMemberSerialization(objectType, contract.MemberSerialization);
            return contract;
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
