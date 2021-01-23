    class Foo {
    	protected int x;
    
    	public void setX(int x) {
    		this.x = x;
    	}
    }
    
    class Bar : Foo {
    	Foo myFoo = new Foo();
    
    	public void someMethod() {
    		this.x = 5;    // valid. You are accessing your own variable
    		myFoo.x = 5;   // invalid. You are attempting to access the protected
                           // property externally
    		myFoo.setX(5); // valid. Using a public setter
    	}
    }
