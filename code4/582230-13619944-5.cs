    public void SendRequestToService1()
    {
        var subSub = new SubSubC();
        Initialize(this.baseA, subSub);
        (new MyServiceObject()).ServiceMethod1(subSub);
    }
    public void SendRequestToService2()
    {
        var subSub = new SubSubE();
        Initialize(this.baseA, subSub);
        (new MyServiceObject()).ServiceMethod2(subSub);
    }
