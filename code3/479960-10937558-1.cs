    class F {
        public readonly Action Foo;
        public F () {
    	    int c = 0; // closured
    	    Foo = () => {
    	        Console.WriteLine(c);
                c++;
            };
    	}
    }
    var f = new F();
    f.Foo();  // 0
    f.Foo();  // 1
