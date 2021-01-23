    // THIS WORKS!!!
    class MyBaseClass0
    {
        // no default constructor - created automatically for you
    }
    class DerivedClass0 : MyBaseClass0
    {
        // no default constructor - created automatically for you and calls the base class default constructor above
    }
    
    // THIS WORKS!!!
    class MyBaseClass1
    {
        // same as above
    }
    class DerivedClass1 : MyBaseClass1
    {
        public DerivedClass1()
        {
          // here the derived class default constructor is created explicitly but the call to the base class default constructor is implicitly called
        }
    }
    // AND THIS WORKS!!!
    class MyBaseClass2
    {
        // as above
    }
    class DerivedClass2 : MyBaseClass2
    {
        public DerivedClass2() : base()
        {
           // here we explicitly call the default constructor in the base class using base(). note its optional as base constructor would be called anyway here
        }
    }
    // AND THIS WORKS!!!
    class MyBaseClass3
    {
        // no default constructor
    }
    class DerivedClass3 : MyBaseClass3
    {
        public DerivedClass3(int x)//non-default constructor
        {
           // as above, the default constructor in the base class is called behind the scenes implicitly here
        }
    }
    // AND THIS WORKS
    class MyBaseClass4
    {
        // non default constructor but missing default constructor
        public MyBaseClass4(string y)
        {
    
        }
    }
    class DerivedClass4 : MyBaseClass4
    {
        // non default constructor but missing default constructor
        public DerivedClass4(int x) : base("hello")
        {
           // note that here, we have fulfilled the requirement that some constructor be called in base even if its not default
        }
    }
    // BUT THIS FAILS!!!...until you either add in a base() call to the non-default constructor or add in the default constructor into base!
    class MyBaseClass5
    {
        // 1. EITHER ADD MISSING DEFAULT CONSTRUCTOR HERE....
        //public MyBaseClass5() { }
    
        // non default constructor but missing default constructor
        public MyBaseClass5(string y)
        {
    
        }
    }
    class DerivedClass5 : MyBaseClass5
    {
        // non default constructor but missing default constructor
        public DerivedClass5(int x)// 2. OR ADD explicit call here (base("hello")) to parameter-based constructor
        {
    
        }
    }
