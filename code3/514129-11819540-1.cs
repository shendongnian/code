    class SomeType
    {
        private int _x = 12;//declare and init
           
        public SomeType()
        { 
           _x = 12;//compiler inserted that line
        }
    
        public SomeType(BlahBlahType blahBlahObject)
        {
            _x = 12;//compiler inserted that line
        }
        //other constructors will also have _x = 12; line 
    }
