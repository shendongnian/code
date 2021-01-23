       [DisplayName("ParentID")]
        public int Parent { 
               get {
                   return Member.Parent
               }; 
               set {
                   Member.Parent = value;
               }
        }
        [DisplayName("ChildID")]
        public Person Child {
               get {
                   return Member.Child
               }; 
               set {
                   Member.Child = value;
               }
        }
