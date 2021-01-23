    public static IAaa<Y> Get(bool b)
    {
        if(b)
            return (IAaa<Y>)(new Bbb());
        else
            return (IAaa<Y>)(new Ccc());
    }
