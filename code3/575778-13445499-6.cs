    public static class KeyFinder
    {
        private static Dictionary<OperatorType, EnumKeyAttribute> lookupTable =
            new Dictionary<OperatorType, EnumKeyAttribute>();
        public static EnumKeyAttribute GetKey(this OperatorType type)
        {
            if (lookupTable.ContainsKey(type))
            {
                return lookupTable[type];
            }
            MemberInfo memberInfo = typeof(OperatorType).GetMember(type.ToString()).FirstOrDefault();
            if (memberInfo != null)
            {
                EnumKeyAttribute attribute = (EnumKeyAttribute)memberInfo.GetCustomAttributes(typeof(EnumKeyAttribute), false).FirstOrDefault();
                if (attribute != null)
                {
                    lookupTable.Add(type, attribute);
                    return attribute;
                }
            }
            // add a null value so next time it doesn't use reflection only to find nothing
            lookupTable.Add(type, null);
            return null;
        }
    }
