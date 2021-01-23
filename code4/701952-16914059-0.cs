    public class Child {
            public int ChildId { get; set; }
            public string ChildName {get;set;}
            [ForeignKey("Parent")]
            public int ParentId { get; set; } //ForeignKey  
            public Parent Parent{get; set;}
            
            public List<Friend>   Friends        { get; set; }
            public List<Friend>   FamilyFriends  { get; set; }
        }
        public class Parent {
            public int ParentId { get; set; }
            public string ParentName {get;set;}
            public List<Friend>   Friends        { get; set; }
            public List<Child>    Children        { get; set; }
        }
        
        public class Friend
        {
            public int FriendId { get; set; }
            public string FriendName {get;set;}
            
            [ForeignKey("Parent ")]
            public int ParentId{get;set;}
            public Friend Parent {get;set;}
            [ForeignKey("Child")]
            public int ChildId{get;set;}
            [InverseProperty("Friends")]
            public Child Child {get;set;}
             [ForeignKey("ChildFam")]
            public int ChildFamId{get;set;}
            [InverseProperty("FamilyFriends")]
            public Child ChildFam {get;set;}
        }
