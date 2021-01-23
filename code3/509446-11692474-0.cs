    [ProtoContract]
    public class PropertyInfoSurrogate {
        [ProtoMember(1)]
        public Type Type { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        public static operator implicit PropertyInfoSurrogate(PropertyInfo value) {
            if(value == null) return null;
            return new PropertyInfoSurrogate {
                 Type = value.DeclaringType, Name = value.Name
            };
        }
        public static operator implicit PropertyInfo(PropertyInfoSurrogate value) {
            if(value == null) return null;
            return value.Type.GetProperty(value.Name);
        }
    }
