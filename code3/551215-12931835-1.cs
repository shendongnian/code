    public void Bang()
    {
    	Action baseMethod = base.Foo<string>;
    	Action bang = new Action(delegate { baseMethod(); });
    	bang();    //VerificationException is thrown
    }
