    //Double an int is invoked 3 times, each time dealing with one integer.
    public int DoubleAnInt(int x)
    {
        return x+x;   
    }
    public void CallsDoubleAnInt()
    {
        int a = 1;
        int b = DoubleAnInt(a);
        int c = DoubleAnInt(b);
        int d = DoubleAnInt(c);
    }
    
