    interface ITest { }
    class Test : ITest { }
    //in a method
    Object obj = new Test();
    ITest test = (ITest)obj;
