    class A {
        public A() {
    
        }
    
        public void DoSomething() { }
    }
    
    class B : A {
        public B() {
    
        }
    
        public void DoSomethingBetter() { }
    }
    
    class C : A {
        public C() {
    
        }
    
        public void DoSomethingBest() { }
    }
    
    class Runner {
        public static void Main(String[] args) {
            A objB = new B();
            if (objB is B)
                ((B)objB).DoSomethingBetter();
    
            A objC = new C();
            if (objC is C) 
                ((C)objC).DoSomethingBest();
        }
    }
