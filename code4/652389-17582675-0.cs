    public abstract ProjectBaseClass : IProjectBase
    {
          [Key]
          public int ProjectClassesId {get;set;}
    }
    
    [Table("TPT_BaseClass1")]
    public abstract TPT_Specialized_Base_Class1 : ProjectBaseClass
    {
          //...specialized stuff in here
    }
    [Table("TPT_BaseClass2")]    
    public abstract TPT_Specialized_Base_Class2: ProjectBaseClass
    {
         //...specialized stuff in here
    }
    
    [Table("ConcreteChild")]
    public TPT_Child_Concrete_Class : TPT_Specialized_Base_Class1
    {
          public int TPT_Parent_Concrete_Class_KeyId {get;set;};
    
          [ForeignKey("TPT_Parent_Concrete_Class_KeyId ")]
          TPT_Parent_Concrete_Class ParentSpecializedClass {get;set;};
    
    }
    
    [Table("ConcreteParent")]
    public TPT_Parent_Concrete_Class : TPT_Specialized_Base_Class2
    {
          //optional relationship 
          public int? TPT_Child_Concrete_Class_KeyId {get;set;};
    
          [ForeignKey("TPT_Child_Concrete_Class_KeyId")]
          TPT_Child_Concrete_Class ChildSpecializedClass {get;set;};
    
    }
    
    
    public projectContext: DbContext
    {
         public DbSet<TPT_Specialized_Base_Class1> 
         public DbSet<TPT_Specialized_Base_Class2> 
     
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        // There is no configuration I could find that would make the model above work!
        // However, if you make each TPT_Specialized_Base_Class inherit from different
        // ProjectBaseClass like:
        public ProjectBaseClass1 : IProjectBase
        public ProjectBaseClass2 : IProjectBase
        public TPT_Specialized_Base_Class1 : ProjectBaseClass1 {...}
        // and 
        public TPT_Specialized_Base_Class2 : ProjectBaseClass2 {...}
        // or, more sensible... 
        public TPT_Specialized_Base_Class1 : IProjectBase
        // and 
        public TPT_Specialized_Base_Class2 : IProjectBase
       
        // then you can do the following, making sure you *discover* the child TPT base 
        // class first
        modelBuilder.Entity<TPT_Specialized_Base_Class1>() //this one is inherited by the derived class that has the *required* reference to a TPT derived parent
             .Ignore(x => x.PropertyNamedInErrorMessage);
   
        modelBuilder.Entity<TPT_Specialized_Base_Class2>();
             .Ignore(x => x.PropertyNamedInErrorMessage);
      
        // when I flipped the order of the classes above, it could not determine the 
        // principal end of the relationship, had a invalid multiplicity, or just wouldn't 
        // save...can't really remember what it was crying about...
        
        modelBuilder.Entity<TPT_Child_Concrete_Class>()
         .HasRequired(x => x.TPT_Parent_Concrete_Class ).WithOptional(); 
              & ProjectBaseClass2
        }
    }
