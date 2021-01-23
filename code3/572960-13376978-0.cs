    class ComplexProperty
    {   
        private readonly Func<string> GetParentNameFunc;
        string PropertyName {get; set;}
        string Description {get; set;}
        string GetParentName {get {return GetParentNameFunc(); } }
        public ComplexProperty(Func<string> GetParentNameFunc)
        {
          this.GetParentNameFunc = GetParentNameFunc;
        }
    }
    class Parent
    {
        string Name {get; set;}
        ComplexProperty Property {get; set;}
        
        //...
        //...
        
        SomeMethodOrCtor()
        {
          Property = new ComplexProperty(()=>{ return this.Name; });
        }
    }
    
