        class Base{
            public Base();
            int a;
        }
        class Derived : Base{
            public Derived();
            public int b;
        }
        Base testBase = new Test;
        Base testDerived = new Derived;
        testBase.a = (Derived)testDerived.b; // Downcasting here.
        
