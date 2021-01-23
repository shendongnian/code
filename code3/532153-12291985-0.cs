    enum Status
    {
        OK = 0,
        Warning = 64,
        Error = 256
    }
     
    static void Main(string[] args)
    {
        bool exists;
     
        exists = Enum.IsDefined(typeof(Status), 0);     // exists = true
        exists = Enum.IsDefined(typeof(Status), 1);     // exists = false
    }
