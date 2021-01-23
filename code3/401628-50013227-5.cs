        void Main()
        {
            Derived d = new Derived();
        	Base bb = d;
        	//b.N();//INVALID.  Calls to the type Derived are not possible because bb is of type Base
        	bb.GetType();//The type is Derived.  bb is still of type Derived despite not being able to call members of Test
        }
    
        class Base 
        {
        	public void M() {}
        }
        
        class Derived: Base
        {
        	public void N() {}
        }
