    public virtual string MethodCalledByMethod1 {
    }
    public virtual string MethodCalledByMethod2 {
    }
    public virtual string MethodCalledByMethod3 {
    }
    public string Method1 {
        if(myCheck()) throw new Exception(...);
        return MethodCalledByMethod1();
    }
    public string Method2 {
        if(myCheck()) throw new Exception(...);
        return MethodCalledByMethod2();
    }
    public string Method3 {
        if(myCheck()) throw new Exception(...);
        return MethodCalledByMethod3();
    }
