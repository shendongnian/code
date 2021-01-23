    class BaseClass
    {
        public bool IsValid {set;get;}
        public BaseClass(Object Param)
        {
            // Do checks and set the value of property
             this.IsValid=false; // or true
        }
    }
    
    class NewClass : BaseClass
    {
        public NewClass(Object Param) : base(Param)
        {
            if(this.IsValid)
            {
              // Code here
            }
        }
    }
