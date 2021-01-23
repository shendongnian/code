    public static event SomeEventType ConnectionCreated;
    static DbConnection CreateConnection() {
        var conn = ExistingDbCreationCode();
        var hadler = ConnectionCreated;
        if(handler != null) {
            var args = new SomeEventArgsType { Connection = conn };
            handler(typeof(YourType), args);
            conn = args.Connection;
        }
        return conn;
    }
