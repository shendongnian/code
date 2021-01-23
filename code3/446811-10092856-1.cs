    static Lister _lister = new Lister();
    private static void Main() {
        Interpreter = new Lua();
    
        Interpreter.RegisterFunction("dump", _lister,
        _lister.GetType().GetMethod("ListObjectMembers"));
    }
