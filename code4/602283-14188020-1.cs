    private int MyProperty { get; set; }
    #if UNIT_TEST
        public int AccessMyProperty
        {
            get { return(MyProperty); }
            set { MyProperty = value; }
        }
    #endif 
