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
            B objAB = objB as B;
			if (objAB != null)
                objAB.DoSomethingBetter();
    
            A objC = new C();
			C objAC = objC AS C;
            if (objAC != null) 
                objAC.DoSomethingBest();
        }
    }
