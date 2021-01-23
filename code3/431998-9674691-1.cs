    public class User
    {
        public int Id { get; set; }
        public int Username { get; set; }
    
        // this is necessary to have access to the related SomeEntityAs/SomeEntityBs
        // also it cant be private otherwise EF will not overload it properly
        public virtual ICollection<SomeEntity> SomeEntities { get; set; }
        
        public IEnumerable<SomeEntityA> SomeEntitiesA { get { return this.SomeEntities.OfType<SomeEntityA>(); } }
        public IEnumerable<SomeEntityB> SomeEntitiesB { get { return this.SomeEntities.OfType<SomeEntityA>(); } }
    }
