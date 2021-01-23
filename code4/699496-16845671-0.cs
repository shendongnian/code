    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CLSASafeAttribute : Attribute {
        public CLSASafeAttribute(Boolean safe) {
            CLSSafe = safe;
        }
        public CLSASafeAttribute(BaseTypes type) {
            CLSSafe = IsCLSSafe(type);
        }
        public Boolean CLSSafe {
            get;
            private set;
        }
        public static bool IsCLSSafe(BaseTypes type) {
            var fieldInfo = typeof(BaseTypes).GetField(typeof(BaseTypes).GetEnumName(type));
            var attributes = fieldInfo.GetCustomAttributes(typeof(CLSASafeAttribute), false);
            return (attributes.Length > 0) && ((CLSASafeAttribute)attributes[0]).CLSSafe;
        }
    }
