    public class Human
    {
        public int HumanId {get;set;}
        public int Gender {get;set;} // 0 = male, 1 = female
    
        public int ParentId { get; private set; }
        public virtual Human Parent { get; private set;}
        public int FatherId {get; private set;}
        public virtual Human Father {get; private set;}
    
        public int MotherId {get; private set;}
        public virtual Human Mother {get; private set;}
    
        public virtual List<Human> Children {get;set;}        
        public void SetParent(Human parent)
        {
            Parent = parent;
            if (parent.Gender ==0)
              Father = parent;
            else
              Mother = parent;
        }
    }
