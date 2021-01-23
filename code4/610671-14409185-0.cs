    public void MyMethod(string s)
    {
        MyMethod(s, 0, null);
    }
    public void MyMethod(int i)
    {
        MyMethod(null, i, null);
    }
    public void MyMethod(MyType t)
    {
        MyMethod(null, 0, t);
    }
    public void MyMethod(string s = null, int i = 0, MyType t = null)
    { 
        /* body */ 
    }
