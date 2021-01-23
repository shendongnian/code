    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class HandlerAttribute : Attribute
    {
        public string MainName { get; private set; }
        public string SubName { get; private set; }
        public HandlerAttribute(string pValue, bool pIsMain) {
            if (pIsMain) MainName = pValue;
            else SubName = pValue;
        }
        public HandlerAttributeData GetData(MemberInfo info)
        {
            if (info is Type)
            {
                return new HandlerAttributeData(MainName, null);
            }
            HandlerAttribute attribute = (HandlerAttribute)info.DeclaringType.GetCustomAttributes(typeof(HandlerAttribute), true)[0];
            return new HandlerAttributeData(attribute.MainName, SubName);
        }
    }
    class HandlerAttributeData
    {
        public string MainName { get; private set; }
        public string SubName { get; private set; }
        public HandlerAttributeData(String mainName, String subName)
        {
            MainName = mainName;
            SubName = subName;
        }
    }
