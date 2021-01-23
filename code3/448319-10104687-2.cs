    [DataContract]
    public class FieldType : IObjectReference
    {
        object IObjectReference.GetRealObject(StreamingContext ctx)
            switch(Id) {
                case 1: return Default;
                case 2: return Name; // note this is a collision between static/non-static
                case 3: return Etc;
                default: throw new InvalidOperationException();
            }
        }
        public static readonly FieldType Default  = new FieldType(1, "Default");
        // note this is a collision between static/non-static
        public static readonly FieldType Name     = new FieldType(2, "Name");
        public static readonly FieldType Etc      = new FieldType(3, "Etc");
    
        private FieldType(uint id, string name)
        {
            Id = id;
            Name = name; // note this is a collision between static/non-static
        }
    
        [DataMember] public uint   Id   { get; private set; }
        // note this is a collision between static/non-static
        [DataMember] public string Name { get; private set; }
        //snip other properties
    }
