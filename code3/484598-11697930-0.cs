    class AllPropertiesResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            return objectType.GetProperties()
                .Where(p => p.GetIndexParameters().Length == 0)
                .Cast<MemberInfo>()
                .ToList();
        }
    }
