    public class PropertyWrapper
    {       
        public MyClass Property { private get; set; }
    
        public string FirstProperty
        {
            get { return Property.FirstProperty; } 
        }
    
        public string SecondProperty
        {
            get { return Property.SecondProperty; } 
        }
    }
