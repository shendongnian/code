    class PrivateContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
		    var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			MemberInfo[] fields = objectType.GetFields(flags);
			return fields
			    .Concat(objectType.GetProperties(flags).Where(propInfo => propInfo.CanWrite))
				.ToList();
        }
		
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
               return base.CreateProperties(type, MemberSerialization.Fields);
        }			
    }
