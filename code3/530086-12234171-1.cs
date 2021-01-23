    interface IMyInterface
    {
        void MyFunction();
    }
    void MyMethod(Object obj) 
    {
        var o = obj as IMyInterface;
        if (o != null)
            o.MyFunction();
    }
