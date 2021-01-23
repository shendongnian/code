    public static bool IsConnected {
        get;
        private set;
    }
    public static void Connect(){
        if( IsConnected ){
            // exit, or fail if this is considered an exceptional scenario
        }
        // do work
        IsConnected = true;
    }
    // call
    if( !Foo.IsConnected ){
        Foo.Connect();
    }
