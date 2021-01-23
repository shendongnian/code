    class Foo
    {    
        Public Foo(string p1, string p2)
        {
            Initializing = true;
            _property1= p1; //set the backing store directly, 
                            //skips the side effect in the setter
            Property2 = p2;
            Initializing = false;
        }
    
        bool Initializing;
    
        string _property1;
        string Property1 
        {
            get { return _property1; } 
            set { _property1 = value; DoSomething(); }
        }
    
        string Property2 { get; set; }
    
        public void DoSomething()
        {
            // Do something here
        }
    }
