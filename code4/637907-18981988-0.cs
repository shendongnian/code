    public MyInterface GetNewType() { 
           Type type = Type.GetType( "MyClass", true ); 
           object newInstance = Activator.CreateInstance( type ); 
           return newInstance as MyInterface; 
        } 
