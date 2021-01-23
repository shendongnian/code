    public void Foo()
    {
        Singleton.Instance().Value1++;
    
        if(Singleton.Instance().Value1==10.0)
        {
             Singleton.Instance().Value2 = 20.0;
        }
        else
        {
             Singleton.Instance().Value3 = 30.0;
        }
    }
