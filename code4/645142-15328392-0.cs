    public void F(ref A a, A b){
        a = new A(1);
        b.Property = 12;
        b = new B(2);
    }
    
    public void G(){
        A a = new A(0);
        A b = new A(0);
        F(a,b);
        System.Console.WriteLine(a + " - " + b);
    }
