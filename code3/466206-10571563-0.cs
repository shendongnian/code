    public class MyState : StateAttribute
    { 
        public string MyProperty {get;set;}
    }
    
    // create City, Zip attributes respectively
    
    [MyState {MyProperty = "Test"}]
    public class USStates
    {
        [City]
        public void isNewYork() { }
        [Zip]
        public ZipCode GetZipCode() { }
    }
