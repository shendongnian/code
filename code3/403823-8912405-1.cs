    param p = new param();
        
    // start the thread, and pass in your variable   
    Thread th = new Thread(new ParameterizedThreadStart(MyThreadMethod));
    th.Start(p);
    public void MyThreadMethod(object o)
    {
        // o is your param
        param pv = (param)o;
    }
