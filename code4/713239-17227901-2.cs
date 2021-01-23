       public   class derived_Class : mybaseclass 
        {
           
            public override void mymethod()
            {
                // IF you want to call the base class function as well then you call base.mymethod() ; 
                base.mymethod();
            } 
            
           
        }
    
        class mybaseclass
        {
          
            // When you want to overide a method , you must use Virtual keyword
            public virtual void mymethod()
            {
                  
            }
    
            // This is an overload of overload_method 
            // when you write many methods from same name with different arguments, it's an overload of the method
            public void overload_method()
            {
            } 
            public  void overload_method(string m)
            {
    
            } 
    
            // When you use an overload 
            public void use()
            {
                overload_method();
                overload_method(null); 
            } 
        } 
