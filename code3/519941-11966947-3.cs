    // this can also accept serialization-context parameters if
    // you want to pass your pool in, etc
    public static MyDTO Create()
    {
        // try to get from the pool; only allocate new obj if necessary
        return SomePool.GetMyDTO() ?? new MyDTO();
    }
