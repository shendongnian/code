    public class MyBase
    {
    
        public MyBase(string name)
        {
            Name = name;
        }
    
        public virtual string Name { get; set;}
    }
    
    public class MyExtendedClass : MyBase 
    {
        public MyExtendedClass(string name) : base (name) {   }
    }
