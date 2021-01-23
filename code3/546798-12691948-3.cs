    namespace name.Models
    {
        public partial class ENTITY
        {
            private string _desc = "some default value"; 
            public virtual string DESCRIPTION_ {get {return _desc} set {_desc = value;} }
        }
    }
