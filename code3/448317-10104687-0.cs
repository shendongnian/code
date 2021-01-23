    [DataContract]
    public class FieldType : IObjectReference
    {
        object IObjectReference.GetRealObject(StreamingContext ctx)
            switch(Id) {
                case 1: return Default;
                case 2: return Name;
                case 3: return Etc;
                default: throw new InvalidOperationException();
            }
        }
        public static readonly FieldType Default  = new FieldType(1, "Default");
        public static readonly FieldType Name     = new FieldType(2, "Name");
        public static readonly FieldType Etc      = new FieldType(3, "Etc");
    
        private FieldType(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    
        [DataMember] public uint   Id   { get; private set; }
        [DataMember] public string Name { get; private set; }
        //snip other properties
    }
