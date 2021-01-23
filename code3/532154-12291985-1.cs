    enum Status
    {
        OK = 0,
        Warning = 64,
        Error = 256
    }
     
    static void Main(string[] args)
    {
        bool exists;
     
        // Testing for Integer Values
        exists = Enum.IsDefined(typeof(Status), 0);     // exists = true
        exists = Enum.IsDefined(typeof(Status), 1);     // exists = false
        
        // Testing for Constant Names
        exists = Enum.IsDefined(typeof(Status), "OK");      // exists = true
        exists = Enum.IsDefined(typeof(Status), "NotOK");   // exists = false
    }
