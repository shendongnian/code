    class ComplexProperty
    {
        public string PropertyName {get; set;}
        public string Description {get; set;}
        public string Parent {get; set;}
        public string GetParentName() 
        {
            return this.Parent == null ? null : this.Parent.Name;
        }
    }
    class Parent
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
