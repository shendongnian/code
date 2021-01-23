    Control c1 = null;
    Class1 cl1 = new Class1(c1); //c1 is still null after this call
    Control c2 = null;
    Class1 cl2 = new Class1(ref c2); //c2 is NOT null after this call
    
    class Class1
    {
    	public Class1(Control c)
    	{
    		c = new Control();
    	}
    
    	public Class1(ref Control c)
    	{
    		c = new Control();
    	}
    }
