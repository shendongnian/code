    public class IsParent
    {
        [Key]
        public int PId { get; set; }
        [DisplayName("Parent")]
        public int ParentID { 
               get {
                   return Member.ParentID
               }; 
               set {
                   Member.ParentID = value;
               }
        }
        [DisplayName("Child")]
        public int ChildID {
               get {
                   return Member.ChildID
               }; 
               set {
                   Member.ChildID = value;
               }
        }
        public virtual Member Member { get; set; }    
    }
