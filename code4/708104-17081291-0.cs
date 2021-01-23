    private member ;
    
    public int MyProperty {
        get { return member; }
        private set { member = value; }
    }
    // ...
    member = 2;
    int anotherVariable = MyProperty; // anotherVariable == 2
