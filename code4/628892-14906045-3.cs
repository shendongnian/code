    public static bool IsConnected {
        get;
        private set;
    }
    public static void Connect(){
        // do work
        IsConnected = true;
    }
    // call
    if( !Foo.IsConnected ){
        Foo.Connect();
    }
