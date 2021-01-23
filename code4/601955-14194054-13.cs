       [DisplayName("Parent")]
        public Person Parent { 
               get {
                   return Member.Parent;
               }; 
               set {
                   Member.Parent = value;
               };
        }
        [DisplayName("Child")]
        public Person Child {
               get {
                   return Member.Child;
               }; 
               set {
                   Member.Child = value;
               };
        }
