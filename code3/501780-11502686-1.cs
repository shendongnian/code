    interface IMyClassFactory
    {
        IMyClass CreateMyClass();
    }
    bool Method(IMyClass myObj, IMyClassFactory myClassFactory)
    {
        if (myObj != null)
        {
            return true;
        }
        myObj = myClassFactory.CreateMyClass();
        return myObj.SomeFunctionReturningBool();
    }
