    class ComplexProperty
    {
        public string PropertyName {get; set;}
        public string Description {get; set;}
        public IParent Parent {get; set;}
        public string GetParentName() 
        {
            return this.Parent == null ? null : this.Parent.Name;
        }
    }
    interface IParent
    {
        string Name {get; set;}
    }
    class Parent : IParent
    {
       public string ParentName {get; set;}
       private ComplexProperty _prop;
       public ComplexProperty Property 
       {
          get { return _prop; }
          set 
          {
              _prop = value;
              _prop.Parent = this; 
          }
       }
    }
