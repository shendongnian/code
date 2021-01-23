    void SomeMethod()
    {
        MyObject o = new MyObject();
        // Do stuff with o
        SomeAsyncMethod(o);
        o.Id = 2222; // will change objects Id property, which will 
                     // be reflected in another thread
    }
